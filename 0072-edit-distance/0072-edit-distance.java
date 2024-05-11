class Solution {
    int[][] dp;

    public int minDistance(String word1, String word2) {
        int w1len = word1.length(), w2len = word2.length();
        dp = new int[w1len][w2len];
        for(var i=0; i<w1len; i++)
            for(var j=0; j<w2len; j++)
                dp[i][j] = -1;

        return minDistance(word1, word2, 0, 0);
    }

    public int minDistance(String word1, String word2, int w1, int w2) {
        int w1len = word1.length(), w2len = word2.length();
        
        if(w1 == w1len) return  w2len-w2;   // all remaining chars will have to be inserted
        if(w2 == w2len) return  w1len-w1;   // all extra chars will have to be deleted

        if(dp[w1][w2] != -1) return dp[w1][w2];

        if(word1.charAt(w1) == word2.charAt(w2))
            dp[w1][w2] = minDistance(word1, word2, w1+1, w2+1);  // no operations needed for current chars
        else{
            // we can do 3 operations : insert, delete or replace
            var minOp = Integer.MAX_VALUE;
            minOp = Math.min(minOp, 1 + minDistance(word1, word2, w1, w2+1));   // insert
            minOp = Math.min(minOp, 1 + minDistance(word1, word2, w1+1, w2));   // delete
            minOp = Math.min(minOp, 1 + minDistance(word1, word2, w1+1, w2+1)); // replace
            
            dp[w1][w2] = minOp;
        }

        return dp[w1][w2];
    }
}