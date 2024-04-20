public class Solution {
    public int MaxProfit(int[] prices) {
        int min=prices[0], maxProfit=0;
        foreach(var p in prices){
            maxProfit = Math.Max(maxProfit, p - min);
            min = Math.Min(p, min);
        }
        return maxProfit;
    }
}