public class Solution {
    public int MaxFreqSum(string s) {
        var vowels = new HashSet<char>{ 'a', 'e', 'i', 'o', 'u' };
        var freq = new int[26];
        int v = 0, c = 0;

        foreach(var ch in s){
            freq[ch-'a']++;
            if(vowels.Contains(ch)) v = Math.Max(v, freq[ch-'a']);
            else c = Math.Max(c, freq[ch-'a']);
        }

        return v + c;
    }
}