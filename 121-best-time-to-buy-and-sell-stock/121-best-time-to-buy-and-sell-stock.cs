public class Solution {
    public int MaxProfit(int[] prices) {
        if(prices.Length == 0) return 0;
        
        int min=prices[0], maxProfit=0;
        foreach(var p in prices){
            maxProfit = Math.Max(maxProfit, p - min);
            min = Math.Min(p, min);
        }
        return maxProfit;
    }
}