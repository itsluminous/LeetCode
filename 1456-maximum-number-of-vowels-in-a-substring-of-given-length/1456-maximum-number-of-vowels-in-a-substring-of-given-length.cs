public class Solution {
    public int MaxVowels(string s, int k) {
        var isVowel = new bool[26];
        isVowel['a'-'a'] = isVowel['e'-'a'] = isVowel['i'-'a'] = isVowel['o'-'a'] = isVowel['u'-'a'] = true;

        var curr = 0;
        for(var i=0; i<k; i++)
            if(isVowel[s[i]-'a']) curr++;
        var max = curr;

        for(var i = k; i<s.Length; i++){
            if(isVowel[s[i]-'a']) curr++;
            if(isVowel[s[i-k]-'a']) curr--;
            max = Math.Max(max, curr);
        }

        return max;
    }
}