public class Solution {
    int[,] dp;

    public int MinDistance(string word1, string word2) {
        int w1len = word1.Length, w2len = word2.Length;
        dp = new int[w1len,w2len];
        for(var i=0; i<w1len; i++)
            for(var j=0; j<w2len; j++)
                dp[i,j] = -1;

        return MinDistance(word1, word2, 0, 0);
    }

    public int MinDistance(string word1, string word2, int w1, int w2) {
        int w1len = word1.Length, w2len = word2.Length;
        
        if(w1 == w1len) return  w2len-w2;
        if(w2 == w2len) return  w1len-w1;

        if(dp[w1,w2] != -1) return dp[w1,w2];

        if(word1[w1] == word2[w2])
            dp[w1,w2] = MinDistance(word1, word2, w1+1, w2+1);  // no operations needed for current chars
        else{
            // we can do 3 operations : insert, delete or replace
            var minOp = int.MaxValue;
            minOp = Math.Min(minOp, 1 + MinDistance(word1, word2, w1, w2+1));   // insert
            minOp = Math.Min(minOp, 1 + MinDistance(word1, word2, w1+1, w2));   // delete
            minOp = Math.Min(minOp, 1 + MinDistance(word1, word2, w1+1, w2+1)); // replace
            
            dp[w1,w2] = minOp;
        }

        return dp[w1,w2];
    }
}