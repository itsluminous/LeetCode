class Solution {
    private int[][] dp;

    public int minimumDeleteSum(String s1, String s2) {
        dp = new int[s1.length() + 1][s2.length() + 1];
        for(int[] row : dp) Arrays.fill(row, -1);
        return minimumDeleteSum(s1, 0, s2, 0);
    }

    private int minimumDeleteSum(String s1, int idx1, String s2, int idx2) {
        if(dp[idx1][idx2] != -1) return dp[idx1][idx2];
        
        // s1 exhausted, delete all remaining chars in s2
        if(idx1 == s1.length()) {
            var sum = 0;
            for(var i = idx2; i < s2.length(); i++) sum += s2.charAt(i);
            return sum;
        }
        
        // s2 exhausted, delete all remaining chars in s1
        if(idx2 == s2.length()) {
            int sum = 0;
            for(var i = idx1; i < s1.length(); i++) sum += s1.charAt(i);
            return sum;
        }

        var result = 0;
        // if characters match, no deletion needed
        if(s1.charAt(idx1) == s2.charAt(idx2))
            result = minimumDeleteSum(s1, idx1+1, s2, idx2+1);
        else {
            // delete char from s1
            var deleteFromS1 = s1.charAt(idx1) + minimumDeleteSum(s1, idx1+1, s2, idx2);
            
            // delete char from s2
            var deleteFromS2 = s2.charAt(idx2) + minimumDeleteSum(s1, idx1, s2, idx2+1);
            
            result = Math.min(deleteFromS1, deleteFromS2);
        }
        
        dp[idx1][idx2] = result;
        return result;
    }
}