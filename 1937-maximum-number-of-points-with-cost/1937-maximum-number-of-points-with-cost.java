class Solution {
    public long maxPoints(int[][] points) {
        int m = points.length, n = points[0].length;
        var dp = new long[m+1][n+1];
        for(var i=0; i<n; i++)
            dp[0][i] = points[0][i];
        
        for(var row=1; row<m; row++){
            long[] left = new long[n], right = new long[n];
            
            // calculate max possible point if comparing with any idx on left in prev row
            left[0] = dp[row-1][0];
            for(var col=1; col<n; col++)
                left[col] = Math.max(left[col-1] - 1, dp[row-1][col]);
            
            // calculate max possible point if comparing with any idx on right in prev row
            right[n-1] = dp[row-1][n-1];
            for(var col=n-2; col >= 0; col--)
                right[col] = Math.max(right[col+1] - 1, dp[row-1][col]);
            
            // calculate max possible point from left or right
            for(var col=0; col<n; col++)
                dp[row][col] = points[row][col] + Math.max(left[col], right[col]);
        }

        long ans = Long.MIN_VALUE;
        for(var i=0; i<n; i++)
            ans = Math.max(ans, dp[m-1][i]);
        
        return ans;
    }
}

// recursive soln times out
class SolutionTLE {
    long[][] dp;

    public long maxPoints(int[][] points) {
        dp = new long[points.length][points[0].length];
        for(var i=0; i<points.length; i++)
            for(var j=0; j<points[0].length; j++)
                dp[i][j] = Integer.MIN_VALUE;

        long maxp = 0;
        for(var i=0; i<points[0].length; i++)
            maxp = Math.max(maxp, points[0][i] + helper(points, i, 1));
        return maxp;
    }

    private long helper(int[][] points, int prevCol, int row){
        if(row == points.length) return 0;
        if(dp[row][prevCol] != Integer.MIN_VALUE) return dp[row][prevCol];

        long currmax = 0;
        for(var i=0; i<points[0].length; i++){
            var pt = points[row][i] - Math.abs(prevCol - i);
            currmax = Math.max(currmax, pt + helper(points, i, row+1));
        }

        dp[row][prevCol] = currmax;
        return currmax;
    }
}