// the robot can only touch m-1 + n-1 cells in grid, no matter what path you take
// these (m+n-2) paths can vary based on when you take down vs when you take right
// so possible ways to touch these cells are (m+n-2)C(m-1)
// i.e. (m+n-2)! / (m-1)! * (n-1)!
// refer https://betterexplained.com/articles/easy-permutations-and-combinations/
public class Solution {
    public int UniquePaths(int m, int n) {
        long ans = 1;
        for(int i = m+n-2, j = 1; i >= Math.Max(m, n); i--, j++)
            ans = (ans * i) / j;
        return (int)ans;
    }
}

// Accepted - only one row space
public class Solution1d {
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