class Solution {
    public long getDescentPeriods(int[] prices) {
        long descents = 0, curr = 1;
        for(var i=1; i<prices.length; i++){
            if(prices[i-1]-prices[i] == 1)
                curr++;
            else{
                descents += apSum(curr);
                curr = 1;
            }
        }
        return descents + apSum(curr);
    }
    
    private long apSum(long n){
        return (n*(n+1))/2;
    }
}