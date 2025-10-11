public class Solution {
    public long MaximumTotalDamage(int[] power) {
        var n = power.Length;
        long[] dp = new long[n+1];
        long max_dp = 0, ans = 0;

        Array.Sort(power);
        for(int l=0, r=0; r<n; r++){
            // if curr power is same as prev
            if(power[r] == power[Math.Max(0, r-1)]){
                dp[r+1] = power[r] + dp[r];
                ans = Math.Max(ans, dp[r+1]);
            }
            else {
                // move l to find best dp value
                while(power[r] > power[l] + 2)
                    max_dp = Math.Max(max_dp, dp[++l]);
                dp[r+1] = power[r] + max_dp;
                ans = Math.Max(ans, dp[r+1]);
            }
        }

        return ans;
    }
}