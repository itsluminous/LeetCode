class Solution {
    public int numberOfSubmatrices(char[][] grid) {
        int m = grid.length, n = grid[0].length;
        var count = 0;

        var dp = new int[m][n][2];    // count of X & Y in each cell
        dp[0][0] = GetCount(grid[0][0], 0, 0, 0, 0);
        
        // first col
        for(var i=1; i<m; i++){
            var prev = dp[i-1][0];
            dp[i][0] = GetCount(grid[i][0], prev[0], prev[1], 0, 0);
            count += IsValid(dp[i][0]);
        }

        // first row
        for(var i=1; i<n; i++){
            var prev = dp[0][i-1];
            dp[0][i] = GetCount(grid[0][i], prev[0], prev[1], 0, 0);
            count += IsValid(dp[0][i]);
        }

        // others
        for(var i=1; i<m; i++){
            for(var j=1; j<n; j++){
                var prev1 = dp[i-1][j];
                var prev2 = dp[i][j-1];
                var prev3 = dp[i-1][j-1];
                dp[i][j] = GetCount(grid[i][j], prev1[0] - prev3[0], prev1[1] - prev3[1], prev2[0], prev2[1]);
                count += IsValid(dp[i][j]);
            }
        }

        return count;
    }

    private int[] GetCount(char ch, int prevX1, int prevY1, int prevX2, int prevY2){
        if(ch == 'X') return new int[]{prevX1 + prevX2 + 1, prevY1 + prevY2};
        if(ch == 'Y') return new int[]{prevX1 + prevX2, prevY1 + prevY2 + 1};
        return new int[]{prevX1 + prevX2, prevY1 + prevY2};
    }

    private int IsValid(int[] xy){
        if(xy[0]== 0) return 0;
        if(xy[0]!= xy[1]) return 0;

        return 1;
    }
}