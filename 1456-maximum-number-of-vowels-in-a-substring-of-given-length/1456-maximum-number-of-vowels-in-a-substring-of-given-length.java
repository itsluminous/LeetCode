public class Solution {
    public int maxVowels(String s, int k) {
        var isVowel = new boolean[26];
        isVowel['a'-'a'] = isVowel['e'-'a'] = isVowel['i'-'a'] = isVowel['o'-'a'] = isVowel['u'-'a'] = true;

        int max = 0, curr = 0;
        var c = s.toCharArray();
        for(var i = 0; i<c.length; i++){
            if(isVowel[c[i]-'a']) curr++;
            if(i >= k)
                if(isVowel[c[i-k]-'a']) curr--;
            max = Math.max(max, curr);
        }

        return max;
    }
}