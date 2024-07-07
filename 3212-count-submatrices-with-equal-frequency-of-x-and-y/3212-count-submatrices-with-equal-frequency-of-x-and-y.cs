public class Solution {
    public int NumberOfSubmatrices(char[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        var count = 0;

        var dp = new (int x, int y)[m,n];    // count of X & Y in each cell
        dp[0,0] = GetCount(grid[0][0], 0, 0, 0, 0);
        
        // first col
        for(var i=1; i<m; i++){
            var (x,y) = dp[i-1, 0];
            dp[i,0] = GetCount(grid[i][0], x, y, 0, 0);
            count += IsValid(dp[i,0]);
        }

        // first row
        for(var i=1; i<n; i++){
            var (x,y) = dp[0, i-1];
            dp[0,i] = GetCount(grid[0][i], x, y, 0, 0);
            count += IsValid(dp[0,i]);
        }

        // others
        for(var i=1; i<m; i++){
            for(var j=1; j<n; j++){
                var (x1,y1) = dp[i-1, j];
                var (x2,y2) = dp[i, j-1];
                var (x3,y3) = dp[i-1, j-1];
                dp[i,j] = GetCount(grid[i][j], x1 - x3, y1 - y3, x2, y2);
                count += IsValid(dp[i,j]);
            }
        }

        return count;
    }

    private (int, int) GetCount(char ch, int prevX1, int prevY1, int prevX2, int prevY2){
        if(ch == 'X') return (prevX1 + prevX2 + 1, prevY1 + prevY2);
        if(ch == 'Y') return (prevX1 + prevX2, prevY1 + prevY2 + 1);
        return (prevX1 + prevX2, prevY1 + prevY2);
    }

    private int IsValid((int x, int y) xy){
        if(xy.x == 0) return 0;
        if(xy.x != xy.y) return 0;

        return 1;
    }
}