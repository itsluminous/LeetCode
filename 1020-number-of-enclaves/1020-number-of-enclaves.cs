public class Solution {
    (int, int)[] dirs = [(0, 1), (0, -1), (1, 0), (-1, 0)];

    public int NumEnclaves(int[][] grid) {
        int m = grid.Length, n = grid[0].Length;

        // visit all 1's starting from border
        for(var i=0; i<m; i++)
            for(var j=0; j<n; j++)
                if(grid[i][j] == 1 && (i == 0 || j == 0 || i == m-1 || j == n-1))
                    MarkConnected(grid, i, j);

        // count unmarked 1's
        var enclaves = 0;
        for(var i=0; i<m; i++)
            for(var j=0; j<n; j++)
                if(grid[i][j] == 1)
                    enclaves++;
        
        return enclaves;
    }

    private void MarkConnected(int[][] grid, int x, int y) {
        int m = grid.Length, n = grid[0].Length;
        if(x == -1 || y == -1 || x == m || y == n || grid[x][y] == 0) return;

        grid[x][y] = 0; // mark visited
        foreach(var (dx, dy) in dirs){
            int nx = x + dx, ny = y + dy;
            MarkConnected(grid, nx, ny);
        }
    }
}

