public class Solution {
    public String mergeAlternately(String word1, String word2) {
        int w1 = word1.length(), w2 = word2.length();
        int i = 0, j = 0;
        char[] chars1 = word1.toCharArray(), chars2 = word2.toCharArray();

        var ans = new StringBuilder();
        while(i < w1 && j < w2)
            ans.append(chars1[i++]).append(chars2[j++]);
        
        while(i < w1) ans.append(chars1[i++]);
        while(j < w2) ans.append(chars2[j++]);

        return ans.toString();
    }
}