public class Solution {
    public int LenOfVDiagonal(int[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        (int dx, int dy)[] dirs = [(1, 1), (1, -1), (-1, -1), (-1, 1)];
        int[] nextNum = [2, 2, 0]; // 0 -> 2 -> 0
        var maxCount = 0;
        var dp = new int[m, n, 4, 2];   // row, col, direction, hasTurned

        int PathLen(int x, int y, int num, int dirIdx, int hasTurned){
            if(x == -1 || y == -1 || x == m || y == n) return 0;
            if(grid[x][y] != num) return 0;

            if(dp[x, y, dirIdx, hasTurned] > 0)
                return dp[x, y, dirIdx, hasTurned];

            var count = PathLen(x + dirs[dirIdx].dx, y + dirs[dirIdx].dy, nextNum[num], dirIdx, hasTurned);
            if(hasTurned == 0){
                var dir2Idx = (dirIdx + 1) % 4;
                var countTurn = PathLen(x + dirs[dir2Idx].dx, y + dirs[dir2Idx].dy, nextNum[num], dir2Idx, 1);
                count = Math.Max(count, countTurn);
            }
            
            dp[x, y, dirIdx, hasTurned] = 1 + count;
            return 1 + count;
        }

        for(var i = 0; i < m; i++) {
            for(var j = 0; j < n; j++) {
                if(grid[i][j] != 1) continue;
                
                var count = 0;
                for(var dirIdx = 0; dirIdx < 4; dirIdx++)
                    count = Math.Max(count, PathLen(i, j, 1, dirIdx, 0));
                maxCount = Math.Max(maxCount, count);
            }
        }
        
        return maxCount;
    }
}