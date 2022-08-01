public class Solution {
    // using only one row space
    public int UniquePaths(int m, int n) {
        var uniquePathArr = new int[m];
        // we want all values to be 1 by default because there is exactly one way to reach all points in first row
        for(var i=0; i<m; i++)
            uniquePathArr[i] = 1;
        
        for(var j=1; j<n; j++){         // start from 1 because 1st row we know will have one way only
            for(var i=1; i<m; i++){     // start from 1 because 0 index will always have only one way to reach
                uniquePathArr[i] += uniquePathArr[i-1];
            }
        }
        
        return uniquePathArr[m-1];
    }
}

// Accepted - using tabulization
public class Solution2 {
    public int UniquePaths1(int m, int n) {
        var tab = new int[m][];
        for(var i=0; i<m; i++) tab[i] = new int[n];
        
        for(int i=0; i<m; i++) tab[i][0] = 1;   // always one way for first col
        for(int j=0; j<n; j++) tab[0][j] = 1;   // always one way for first row
        
        for(int i=1; i<m; i++)
            for(int j=1; j<n; j++)
                tab[i][j] = tab[i-1][j] + tab[i][j-1];
        
        return tab[m-1][n-1];
    }
}

// TLE - Need to add memoisation
public class Solution1 {
    public int UniquePaths(int m, int n) {
        return UniquePaths(m,n,0,0);
    }
    
    private int UniquePaths(int m, int n, int x, int y){
        if(x==m-1 && y==n-1) return 1;
        if(x == m || y == n) return 0;
        
        return UniquePaths(m,n,x+1,y) + UniquePaths(m,n,x,y+1);
    }
}