public class Solution {
    private int[,] dp;

    public int MinimumDeleteSum(string s1, string s2) {
        int n = s1.Length, m = s2.Length;
        dp = new int[n + 1, m + 1];
        for(var i = 0; i <= n; i++)
            for(var j = 0; j <= m; j++)
                dp[i, j] = -1;
        return MinimumDeleteSum(s1, 0, s2, 0);
    }

    private int MinimumDeleteSum(String s1, int idx1, String s2, int idx2) {
        if(dp[idx1, idx2] != -1) return dp[idx1, idx2];
        
        // s1 exhausted, delete all remaining chars in s2
        if(idx1 == s1.Length) {
            var sum = 0;
            for(var i = idx2; i < s2.Length; i++) sum += s2[i];
            return sum;
        }
        
        // s2 exhausted, delete all remaining chars in s1
        if(idx2 == s2.Length) {
            int sum = 0;
            for(var i = idx1; i < s1.Length; i++) sum += s1[i];
            return sum;
        }

        var result = 0;
        // if characters match, no deletion needed
        if(s1[idx1] == s2[idx2])
            result = MinimumDeleteSum(s1, idx1+1, s2, idx2+1);
        else {
            // delete char from s1
            var deleteFromS1 = s1[idx1] + MinimumDeleteSum(s1, idx1+1, s2, idx2);
            
            // delete char from s2
            var deleteFromS2 = s2[idx2] + MinimumDeleteSum(s1, idx1, s2, idx2+1);
            
            result = Math.Min(deleteFromS1, deleteFromS2);
        }
        
        dp[idx1, idx2] = result;
        return result;
    }
}