public class Solution {
    public int MaxDifference(string s) {
        var freq = new int[26];
        foreach(var ch in s)
            freq[ch-'a']++;

        int oddFreq = 0, evenFreq = 101;
        foreach(var f in freq){
            if(f == 0) continue;
            if((f & 1) == 1) oddFreq = Math.Max(oddFreq, f);
            else evenFreq = Math.Min(evenFreq, f);
        }

        return oddFreq - evenFreq;
    }
}