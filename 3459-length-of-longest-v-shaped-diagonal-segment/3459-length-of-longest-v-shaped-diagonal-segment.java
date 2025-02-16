class Solution {
    int m, n;
    int[][] dirs = {{1, 1}, {1, -1}, {-1, -1}, {-1, 1}};
    int[] nextNum = {2, 2, 0};  // 0 -> 2 -> 0
    int[][][][] dp;

    public int lenOfVDiagonal(int[][] grid) {
        m = grid.length; n = grid[0].length;
        var maxCount = 0;
        dp = new int[m][n][4][2];   // row, col, direction, hasTurned

        for(var i = 0; i < m; i++) {
            for(var j = 0; j < n; j++) {
                if(grid[i][j] != 1) continue;
                
                var count = 0;
                for(var dirIdx = 0; dirIdx < 4; dirIdx++)
                    count = Math.max(count, pathLen(grid, i, j, 1, dirIdx, 0));
                maxCount = Math.max(maxCount, count);
            }
        }
        
        return maxCount;
    }

    int pathLen(int[][] grid, int x, int y, int num, int dirIdx, int hasTurned){
        if(x == -1 || y == -1 || x == m || y == n) return 0;
        if(grid[x][y] != num) return 0;

        if(dp[x][y][dirIdx][hasTurned] > 0)
            return dp[x][y][dirIdx][hasTurned];

        var count = pathLen(grid, x + dirs[dirIdx][0], y + dirs[dirIdx][1], nextNum[num], dirIdx, hasTurned);
        if(hasTurned == 0){
            var dir2Idx = (dirIdx + 1) % 4;
            var countTurn = pathLen(grid, x + dirs[dir2Idx][0], y + dirs[dir2Idx][1], nextNum[num], dir2Idx, 1);
            count = Math.max(count, countTurn);
        }
        
        dp[x][y][dirIdx][hasTurned] = 1 + count;
        return 1 + count;
    }
}