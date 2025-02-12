public class Solution {
    public int MaxProfit(int[] prices) {
        int profit = 0, lowest = prices[0];
        foreach(var p in prices){
            profit = Math.Max(profit, p - lowest);
            lowest = Math.Min(lowest, p);
        }
        return profit;
    }
}