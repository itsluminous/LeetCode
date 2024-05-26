// Explaination : https://leetcode.com/problems/student-attendance-record-ii/solutions/101652/java-4-lines-dp-solution-with-state-transition-table-explained/
class Solution {
    int[] dp;

    public int checkRecord(int n) {
        dp = new int[]{1, 1, 0, 1, 0, 0};  // initial state for n = 1
        for(var i=2; i<=n; i++){
            dp = new int[]{ dpSum(0, 2), dp[0], dp[1], dpSum(0, 5), dp[3], dp[4] };
        }
        return dpSum(0, 5);
    }

    private int dpSum(int start, int end){
        var MOD = 1_000_000_007;
        var total = 0;
        for(var i=start; i<=end; i++)
            total = (total + dp[i]) % MOD;
        return total;
    }
}