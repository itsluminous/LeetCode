// probability of A emptying first is always more than B because B does not have a case of 100ml usage
// and question also says that answer within 10^-5 of the actual answer will be accepted
// so, probability greater than 0.999995 will be treated as 1
// if we try different different values of n, we will find that for n > 4800, the probability is > 0.999995, i.e. 1
// which basically means that almost all the time A empties first or at same time
// hence for n > 4800 we simply return 1
class Solution {
    Double[][] dp;

    public double soupServings(int n) {
        if(n > 4800) return 1.0;    // explaination in comments on top
        dp = new Double[n+1][n+1];
        return calculate(n, n);
    }

    private double calculate(int a, int b){
        if(a <= 0 && b <= 0) return 0.5;    // both empty - take half of 1.0
        if(a <= 0) return 1.0;              // a empties first
        if(b <= 0) return 0.0;              // b empties first - we don't want to consider this
        if(dp[a][b] != null) return dp[a][b];

        var a100b0 = calculate(a-100, b);
        var a75b25 = calculate(a-75, b-25);
        var a50b50 = calculate(a-50, b-50);
        var a25b75 = calculate(a-25, b-75);
        
        dp[a][b] = (a100b0 + a75b25 + a50b50 + a25b75) / 4;
        return dp[a][b];
    }
}