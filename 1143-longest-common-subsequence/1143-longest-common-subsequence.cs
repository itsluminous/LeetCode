public class Solution {
    public int LongestCommonSubsequence(string text1, string text2) {
        int t1len = text1.Length, t2len = text2.Length;
        var dp = new int[t1len, t2len];
        for(var i=0; i<t1len; i++)
            for(var j=0; j<t2len; j++)
                dp[i,j] = -1;

        return LongestCommonSubsequence(text1, text2, 0, 0, dp);
    }

    private int LongestCommonSubsequence(string text1, string text2, int t1, int t2, int[,] dp) {
        int t1len = text1.Length, t2len = text2.Length;
        if(t1 == t1len || t2 == t2len) return 0;
        if(dp[t1, t2] != -1) return dp[t1, t2];

        if(text1[t1] == text2[t2])
            dp[t1, t2] = 1 + LongestCommonSubsequence(text1, text2, t1+1, t2+1, dp);
        else
            dp[t1, t2] = Math.Max(LongestCommonSubsequence(text1, text2, t1, t2+1, dp), 
                                  LongestCommonSubsequence(text1, text2, t1+1, t2, dp));

        return dp[t1, t2];
    }
}