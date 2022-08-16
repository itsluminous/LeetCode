public class Solution {
    public int FirstUniqChar(string s) {
        var chars = new int[26];
        foreach(var ch in s) chars[ch-'a']++;   // count occurence of each char
        
        // find first non-repeating char
        for(var i=0; i<s.Length; i++)
            if(chars[s[i] - 'a'] == 1) return i;
        return -1;
    }
}