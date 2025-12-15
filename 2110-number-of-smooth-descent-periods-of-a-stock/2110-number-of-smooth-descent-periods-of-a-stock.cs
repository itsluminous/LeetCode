public class Solution {
    public long GetDescentPeriods(int[] prices) {
        long descents = 0, curr = 1;
        for(var i=1; i<prices.Length; i++){
            if(prices[i-1]-prices[i] == 1)
                curr++;
            else{
                descents += APSum(curr);
                curr = 1;
            }
        }
        return descents + APSum(curr);
    }
    
    private long APSum(long n) => (n*(n+1))/2;
}