// find longest common subsequence and then remove that from total len of both strings
public class Solution {
    public int MinDistance(string word1, string word2) {
        int w1 = word1.Length, w2 = word2.Length;
        var dp = new int[w1+1, w2+1];
        for(var i=0; i<=w1; i++)
            for(var j=0; j<=w2; j++){
                if(i==0 || j==0) continue;
                if(word1[i-1] == word2[j-1])
                    dp[i,j] = 1 + dp[i-1,j-1];
                else
                    dp[i,j] = Math.Max(dp[i-1,j], dp[i,j-1]);
            }
        
        return w1+w2 - 2*dp[w1,w2];
    }
}