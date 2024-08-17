public class Solution {
    public long MaxPoints(int[][] points) {
        int m = points.Length, n = points[0].Length;
        var dp = new long[m+1, n+1];
        for(var i=0; i<n; i++)
            dp[0, i] = points[0][i];
        
        for(var row=1; row<m; row++){
            long[] left = new long[n], right = new long[n];
            
            // calculate max possible point if comparing with any idx on left in prev row
            left[0] = dp[row-1, 0];
            for(var col=1; col<n; col++)
                left[col] = Math.Max(left[col-1] - 1, dp[row-1, col]);
            
            // calculate max possible point if comparing with any idx on right in prev row
            right[n-1] = dp[row-1, n-1];
            for(var col=n-2; col >= 0; col--)
                right[col] = Math.Max(right[col+1] - 1, dp[row-1, col]);
            
            // calculate max possible point from left or right
            for(var col=0; col<n; col++)
                dp[row, col] = points[row][col] + Math.Max(left[col], right[col]);
        }

        long ans = long.MinValue;
        for(var i=0; i<n; i++)
            ans = Math.Max(ans, dp[m-1, i]);
        
        return ans;
    }
}