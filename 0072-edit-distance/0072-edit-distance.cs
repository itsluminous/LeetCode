public class Solution {
    int[,] dp;

    public int MinDistance(string word1, string word2) {
        int len1 = word1.Length, len2 = word2.Length;
        dp = new int[len1, len2];
        for(var i=0; i<len1; i++)
            for(var j=0; j<len2; j++)
                dp[i, j] = -1;
        
        return MinDistance(word1, word2, 0, 0);
    }

    private int MinDistance(string word1, string word2, int w1, int w2){
        int len1 = word1.Length, len2 = word2.Length;
        if(w1 == len1 && w2 == len2) return 0;  // no further changes needed
        if(w1 == len1) return len2 - w2;        // insert all remaining chars
        if(w2 == len2) return len1 - w1;        // delete remaining chars
        if(dp[w1, w2] != -1) return dp[w1, w2]; // already evaluated

        var dist = 0;
        
        // if chars at curr index in both words match
        if(word1[w1] == word2[w2])
            dist = MinDistance(word1, word2, w1+1, w2+1);
        else {
            dist = 1 + MinDistance(word1, word2, w1+1, w2+1);               // replace
            dist = Math.Min(dist, 1 + MinDistance(word1, word2, w1+1, w2)); // delete
            dist = Math.Min(dist, 1 + MinDistance(word1, word2, w1, w2+1)); // insert
        }

        dp[w1, w2] = dist;
        return dist;
    }
}