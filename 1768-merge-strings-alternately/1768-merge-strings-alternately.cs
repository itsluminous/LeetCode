public class Solution {
    public string MergeAlternately(string word1, string word2) {
        int w1 = word1.Length, w2 = word2.Length;
        int i = 0, j = 0;

        var ans = new StringBuilder();
        while(i < w1 && j < w2)
            ans.Append(word1[i++]).Append(word2[j++]);
        
        while(i < w1) ans.Append(word1[i++]);
        while(j < w2) ans.Append(word2[j++]);

        return ans.ToString();
    }
}