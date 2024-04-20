public class Solution {
    public int maxProfit(int[] prices) {
        int min=prices[0], maxProfit=0;
        for(var p : prices){
            maxProfit = Math.max(maxProfit, p - min);
            min = Math.min(p, min);
        }
        return maxProfit;
    }
}