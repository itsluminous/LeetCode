public class Solution {
    public long MostPoints(int[][] questions) {
        var n = questions.Length;
        
        // calculate max points achievable when starting from index i
        long maxPossible = 0;
        var maxPoints = new long[n];
        for(var i=n-1; i>=0; i--){
            int points = questions[i][0], brainpower = questions[i][1];
            
            // score if we include curr point
            maxPoints[i] = points;
            var nextIdx = i + brainpower + 1;
            if(nextIdx < n)
                maxPoints[i] += maxPoints[nextIdx];
            
            // if the score after including curr point is bad, skip it
            if(maxPoints[i] < maxPossible) maxPoints[i] = maxPossible;
            else maxPossible = maxPoints[i];
        }

        return maxPossible;
    }
}

// Accepted - DFS with memoization
public class Solutiondfs {
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