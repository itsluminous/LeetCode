public class Solution {
    public int Change(int amount, int[] coins) {
        var dp = new int[amount+1];
        dp[0] = 1;

        foreach(var coin in coins)
            for(var i=coin; i<=amount; i++)
                dp[i] += dp[i-coin];

        return dp[amount];
    }
}