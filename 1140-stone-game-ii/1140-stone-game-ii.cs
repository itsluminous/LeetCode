public class Solution {
    int[] suffixSum;
    int[,] dp;

    public int StoneGameII(int[] piles) {
        var n = piles.Length;
        dp = new int[n,n];

        // calculate prefix sum (from right)
        suffixSum = new int[n+1];
        suffixSum[n] = 0;
        for(var i=n-1; i>=0; i--) suffixSum[i] = piles[i] + suffixSum[i+1];

        return Score(piles, 1, 0);
    }

    private int Score(int[] piles, int m, int idx){
        if(idx == piles.Length) return 0;
        if(idx == piles.Length - 1) return piles[idx];
        if(dp[m,idx] != 0) return dp[m,idx];

        var maxScore = 0;
        for(var i=1; i<= 2*m && idx+i<=piles.Length; i++){
            var take = suffixSum[idx] - suffixSum[idx+i];
            var leftover = suffixSum[idx+i] - Score(piles, Math.Max(m, i), idx+i);
            maxScore = Math.Max(maxScore, take + leftover);
        }

        dp[m,idx] = maxScore;
        return maxScore;
    }
}