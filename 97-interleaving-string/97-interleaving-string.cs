public class Solution {
    int[,] dp;
    
    public bool IsInterleave(string s1, string s2, string s3) {
        int s1len = s1.Length, s2len = s2.Length, s3len = s3.Length;
        if(s1len + s2len != s3len) return false;
        
        dp = new int[s1len, s2len]; // dp[i,j] can be -1 (initial), 1 (Interleave), 0 (not possible)
        for(var i=0; i<s1len; i++)
            for(var j=0; j<s2len; j++)
                dp[i,j] = -1;
        
        return IsInterleave(s1, 0, s2, 0, s3, 0);
    }
    
    public bool IsInterleave(string s1, int s1idx, string s2, int s2idx, string s3, int s3idx) {
        if(s1idx == s1.Length)
            return s2.Substring(s2idx).Equals(s3.Substring(s3idx));
        if(s2idx == s2.Length)
            return s1.Substring(s1idx).Equals(s3.Substring(s3idx));
        if(dp[s1idx, s2idx] >= 0)   // if we have reached this state earlier
            return dp[s1idx, s2idx] == 1;
        
        var isInterleave = 0;
        if(s3[s3idx] == s1[s1idx] && IsInterleave(s1, s1idx+1, s2, s2idx, s3, s3idx+1)  
          || s3[s3idx] == s2[s2idx] && IsInterleave(s1, s1idx, s2, s2idx+1, s3, s3idx+1))
            isInterleave = 1;
        
        dp[s1idx, s2idx] = isInterleave;
        return isInterleave == 1;
    }
}