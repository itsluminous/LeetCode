public class Solution {
    int[,] dp;

    public int StoneGameII(int[] piles) {
        var n = piles.Length;
        dp = new int[n,n];

        // calculate suffix sum (from right)
        for(var i=n-2; i>=0; i--)
            piles[i] += piles[i+1];

        return Score(piles, 1, 0);
    }

    private int Score(int[] suffixSum, int m, int idx){
        if(idx + 2*m >= suffixSum.Length) return suffixSum[idx];    // last player takes it all
        if(dp[m,idx] != 0) return dp[m,idx];

        var maxScore = 0;
        for(var i=1; i<= 2*m; i++){
            var take = suffixSum[idx] - suffixSum[idx+i];
            var leftover = suffixSum[idx+i] - Score(suffixSum, Math.Max(m, i), idx+i);
            maxScore = Math.Max(maxScore, take + leftover);
        }

        dp[m,idx] = maxScore;
        return maxScore;
    }
}