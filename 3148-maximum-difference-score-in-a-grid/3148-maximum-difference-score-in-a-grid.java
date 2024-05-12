// intution is that (a - b) + (b - c) + (c - d) = (a - d)
// so as long as there exists a path between two numbers a and d
// we just need to find difference between them and see if that is highest
class Solution {
    public int maxScore(List<List<Integer>> grid) {
        int m = grid.size(), n = grid.get(0).size();
        var dp = new int[m][n];
        
        // dp to track biggest possible num accessible at each index
        for(var i=0; i<m; i++)
            for(var j=0; j<n; j++)
                dp[i][j] = Integer.MIN_VALUE;
        dp[m-1][n-1] = grid.get(m-1).get(n-1);
        
        // find biggest possible num accessible at each index
        for(var i=m-1; i>=0; i--){
            for(var j=n-1; j>=0; j--){
                if(i < m-1) dp[i][j] = Math.max(dp[i][j], dp[i+1][j]);
                if(j < n-1) dp[i][j] = Math.max(dp[i][j], dp[i][j+1]);
                dp[i][j] = Math.max(dp[i][j], grid.get(i).get(j));
            }
        }
        
        // for each index, find difference between curr number & biggest possible num we can reach from here
        var maxVal = Integer.MIN_VALUE;
        for(var i=0; i<m; i++){
            for(var j=0; j<n; j++){
                if(i < m-1) maxVal = Math.max(maxVal, dp[i+1][j] - grid.get(i).get(j));
                if(j < n-1) maxVal = Math.max(maxVal, dp[i][j+1] - grid.get(i).get(j));
            }
        }
                
        return maxVal;
    }
}