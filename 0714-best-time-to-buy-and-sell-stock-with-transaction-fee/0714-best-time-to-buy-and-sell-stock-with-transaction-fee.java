class Solution {
    public int maxProfit(int[] prices, int fee) {
        int earning = 0, holding = -prices[0];

        for(var i=1; i<prices.length; i++){
            earning = Math.max(earning, holding + prices[i] - fee);
            holding = Math.max(holding, earning - prices[i]);
        }

        return earning;
    }
}