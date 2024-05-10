// simple greedy
public class Solution {
    public int MaxProfit(int[] prices, int fee) {
        // earning denotes how much i have earned so far
        // holding denotes money left with if we purchased certain stock
        int earning = 0, holding = -prices[0];

        for(var i=1; i<prices.Length; i++){
            earning = Math.Max(earning, holding + prices[i] - fee); // completing transaction is good or not
            holding = Math.Max(holding, earning - prices[i]);       // continue holding, or buy new instead
        }

        return earning;
    }
}