public class Solution {
    int[] sq, dp;
    const int MAX = 101;

    public int NumSquares(int n) {
        sq = new int[MAX];
        for(var i=1; i<MAX; i++) sq[i] = i*i;

        dp = new int[10001];
        dp[0] = 0; dp[1] = 1; dp[2] = 2; dp[3] = 3; dp[4] = 1;

        return NumSquaresHelper(n);
    }

    public int NumSquaresHelper(int n) {
        if(dp[n] > 0) return dp[n];
        if(n == 0) return 0;
        var min = Int32.MaxValue;

        for(var i=1; i<MAX; i++){
            if(sq[i] > n) break;
            var include = NumSquaresHelper(n-sq[i]);
            if(include == Int32.MaxValue) continue;
            min = Math.Min(min, 1+include);
        }

        dp[n] = min;
        return min;
    }
}