public class Solution {
    public char FindTheDifference(string s, string t) {
        var letters = new int[26];
        foreach(var ch in s)
            letters[ch-'a']++;
        
        foreach(var ch in t){
            if(letters[ch-'a'] == 0) return ch;
            letters[ch-'a']--;
        }
        return t[0];
    }
}