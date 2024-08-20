class Solution {
    int[] pre;
    int[][] dp;

    public int stoneGameII(int[] piles) {
        var n = piles.length;
        dp = new int[n][n];

        // calculate prefix sum (from right)
        pre = new int[n+1];
        pre[n] = 0;
        for(var i=n-1; i>=0; i--) pre[i] = piles[i] + pre[i+1];

        return score(piles, 1, 0);
    }

    private int score(int[] piles, int m, int idx){
        if(idx == piles.length) return 0;
        if(idx == piles.length - 1) return piles[idx];
        if(dp[m][idx] != 0) return dp[m][idx];

        var maxScore = 0;
        for(var i=1; i<= 2*m && idx+i<=piles.length; i++){
            var take = pre[idx] - pre[idx+i];
            var left = pre[idx+i] - score(piles, Math.max(m, i), idx+i);
            var currScore = take + left;
            maxScore = Math.max(maxScore, currScore);
        }

        dp[m][idx] = maxScore;
        return maxScore;
    }
}