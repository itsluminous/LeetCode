public class Solution {
    public int CountGoodStrings(int low, int high, int zero, int one) {
        var mod = 1_000_000_007;
        var dp = new int[high + 1];
        dp[0] = 1;  // only one way to have string of length 0

        // fill the dp
        for(var i=1; i <= high; i++){
            if(i >= zero)
                // can reach dp[i] by adding "zero" no. of 0
                dp[i] += dp[i-zero];
            
            if(i >= one)
                // can reach dp[i] by adding "one" no. of 1
                dp[i] += dp[i-one];
            
            dp[i] %= mod;
        }

        // count the good strings in range(low, high)
        var count = 0;
        for(var i=low; i<=high; i++){
            count += dp[i];
            count %= mod;
        }

        return count;
    }
}