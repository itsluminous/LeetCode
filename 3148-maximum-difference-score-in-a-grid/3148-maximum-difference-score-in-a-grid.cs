// intution is that (a - b) + (b - c) + (c - d) = (a - d)
// so as long as there exists a path between two numbers a and d
// we just need to find difference between them and see if that is highest
public class Solution {
    public int MaxScore(IList<IList<int>> grid) {
        int m = grid.Count, n = grid[0].Count;
        var dp = new int[m,n];
        
        // dp to track biggest possible num accessible at each index
        for(var i=0; i<m; i++)
            for(var j=0; j<n; j++)
                dp[i,j] = int.MinValue;
        dp[m-1,n-1] = grid[m-1][n-1];
        
        // find biggest possible num accessible at each index
        for(var i=m-1; i>=0; i--){
            for(var j=n-1; j>=0; j--){
                if(i < m-1) dp[i,j] = Math.Max(dp[i,j], dp[i+1,j]);
                if(j < n-1) dp[i,j] = Math.Max(dp[i,j], dp[i,j+1]);
                dp[i,j] = Math.Max(dp[i,j], grid[i][j]);
            }
        }
        
        // for each index, find difference between curr number & biggest possible num we can reach from here
        var maxVal = int.MinValue;
        for(var i=0; i<m; i++){
            for(var j=0; j<n; j++){
                if(i < m-1) maxVal = Math.Max(maxVal, dp[i+1,j] - grid[i][j]);
                if(j < n-1) maxVal = Math.Max(maxVal, dp[i,j+1] - grid[i][j]);
            }
        }
                
        return maxVal;
    }
}