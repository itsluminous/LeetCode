public class Solution {
    public int MaxVowels(string s, int k) {
        var isVowel = new bool[26];
        isVowel['a'-'a'] = isVowel['e'-'a'] = isVowel['i'-'a'] = isVowel['o'-'a'] = isVowel['u'-'a'] = true;

        int max = 0, curr = 0;
        for(var i = 0; i<s.Length; i++){
            if(isVowel[s[i]-'a']) curr++;
            if(i >= k)
                if(isVowel[s[i-k]-'a']) curr--;
            max = Math.Max(max, curr);
        }

        return max;
    }
}