class Solution {
    public int maxProfit(int[] prices) {
        int profit = 0, lowest = prices[0];
        for(var p : prices){
            profit = Math.max(profit, p - lowest);
            lowest = Math.min(lowest, p);
        }
        return profit;
    }
}