public class Solution {
    public int MaxProfit(int k, int[] prices) {
        var n = prices.Length;
        if(n <= 1) return 0;    // can't make any profit without selling stocks
        
        // if no. of allowed transactions > n/2, it means we can buy and sell everyday
        if(k >= n/2){
            var profit = 0;
            for(var i=1; i<n; i++)
                if(prices[i] > prices[i - 1])
                    profit += prices[i] - prices[i-1];
            return profit;
        }
        
        var dp = new int[k+1, n];   // using max k transactions and till n day, what is profit
        for(var trans=1; trans<=k; trans++){
            var currMax = dp[trans-1,0] - prices[0];
            for(var day=1; day<n; day++){
                dp[trans,day] = Math.Max(dp[trans, day-1], prices[day] + currMax);  // max of profit yesterday vs selling today
                currMax = Math.Max(currMax, dp[trans-1, day] - prices[day]);        // max of curr biggest steep vs if i buy today
            }
        }
        return dp[k,n-1];
    }
}