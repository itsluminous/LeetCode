public class Solution {
    public int MinimumLength(string s) {
        // count freq of each char
        var freq = new int[26];
        foreach(var ch in s)
            freq[ch - 'a']++;
        
        // try to reduce all freq to 1 (for odd) & 2 (for even)
        var removed = 0;
        foreach(var num in freq) {
            if(num < 3) continue;  // can't reduce it
            if((num & 1) == 1) removed += num - 1;  // odd freq
            else removed += num - 2;  // even freq
        }
        
        return s.Length - removed;
    }
}