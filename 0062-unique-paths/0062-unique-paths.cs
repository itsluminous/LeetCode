// only one row space
public class Solution {
    public int UniquePaths(int m, int n) {
        var dp = new int[m];
        // There is exactly one way to reach all points in first row
        for(var i=0; i<m; i++) dp[i] = 1;
        
        for(var j=1; j<n; j++)         // start from 1 because 1st row we know will have one way only
            for(var i=1; i<m; i++)     // start from 1 because 0 index will always have only one way to reach
                dp[i] += dp[i-1];
        
        return dp[m-1];
    }
}

// accepted - using 2d array
public class Solution2d {
    public int UniquePaths(int m, int n) {
        var dp = new int[m,n];

        // only one way to reach any cell in top row and leftmost col
        for(var i=0; i<m; i++) dp[i,0] = 1;
        for(var i=0; i<n; i++) dp[0,i] = 1;

        // for every other cell, it can either be reached from above one or left one
        for(var i=1; i<m; i++)
            for(var j=1; j<n; j++)
                dp[i,j] = dp[i-1,j] + dp[i, j-1];
        
        return dp[m-1, n-1];
    }
}