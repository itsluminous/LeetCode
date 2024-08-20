class Solution {
    int[] suffixSum;
    int[][] dp;

    public int stoneGameII(int[] piles) {
        var n = piles.length;
        dp = new int[n][n];

        // calculate prefix sum (from right)
        suffixSum = new int[n+1];
        suffixSum[n] = 0;
        for(var i=n-1; i>=0; i--) suffixSum[i] = piles[i] + suffixSum[i+1];

        return score(piles, 1, 0);
    }

    private int score(int[] piles, int m, int idx){
        if(idx == piles.length) return 0;
        if(idx == piles.length - 1) return piles[idx];
        if(dp[m][idx] != 0) return dp[m][idx];

        var maxScore = 0;
        for(var i=1; i<= 2*m && idx+i<=piles.length; i++){
            var take = suffixSum[idx] - suffixSum[idx+i];
            var leftover = suffixSum[idx+i] - score(piles, Math.max(m, i), idx+i);
            maxScore = Math.max(maxScore, take + leftover);
        }

        dp[m][idx] = maxScore;
        return maxScore;
    }
}