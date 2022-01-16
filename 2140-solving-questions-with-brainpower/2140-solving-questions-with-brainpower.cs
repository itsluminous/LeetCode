// DFS with memoization
public class Solution {
    public long MostPoints(int[][] questions) {
        var dp = new long[questions.Length];
        return MostPoints(questions, dp, 0);
    }
    
    private long MostPoints(int[][] questions, long[] dp, int idx) {
        if(idx >= questions.Length) return 0;   // check for out of bound index
        if(dp[idx] > 0) return dp[idx];         // if we have already calculated it, return that
        
        var q = questions[idx];
        var skip = MostPoints(questions, dp, idx+1);                    // points if we skip current index
        var notSkip = q[0] + MostPoints(questions, dp, idx+q[1]+1);     // points if we don't skip current
        dp[idx] = Math.Max(skip, notSkip);                              // we pick the max of skip and notSkip
        return dp[idx];
    }
}