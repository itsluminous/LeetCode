class Solution {
    public long maximumTotalDamage(int[] power) {
        var n = power.length;
        long[] dp = new long[n+1];
        long max_dp = 0, ans = 0;

        Arrays.sort(power);
        for(int l=0, r=0; r<n; r++){
            // if curr power is same as prev
            if(power[r] == power[Math.max(0, r-1)]){
                dp[r+1] = power[r] + dp[r];
                ans = Math.max(ans, dp[r+1]);
            }
            else {
                // move l to find best dp value
                while(power[r] > power[l] + 2)
                    max_dp = Math.max(max_dp, dp[++l]);
                dp[r+1] = power[r] + max_dp;
                ans = Math.max(ans, dp[r+1]);
            }
        }

        return ans;
    }
}