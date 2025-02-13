class Solution {
    int[][] dirs = {{0, 1}, {0, -1}, {1, 0}, {-1, 0}};

    public int numEnclaves(int[][] grid) {
        int m = grid.length, n = grid[0].length;

        // visit all 1's starting from border
        for(var i=0; i<m; i++)
            for(var j=0; j<n; j++)
                if(grid[i][j] == 1 && (i == 0 || j == 0 || i == m-1 || j == n-1))
                    markConnected(grid, i, j);

        // count unmarked 1's
        var enclaves = 0;
        for(var i=0; i<m; i++)
            for(var j=0; j<n; j++)
                if(grid[i][j] == 1)
                    enclaves++;
        
        return enclaves;
    }

    private void markConnected(int[][] grid, int x, int y) {
        int m = grid.length, n = grid[0].length;
        if(x == -1 || y == -1 || x == m || y == n || grid[x][y] == 0) return;

        grid[x][y] = 0; // mark visited
        for(var dir : dirs){
            int dx = dir[0], dy = dir[1];
            int nx = x + dx, ny = y + dy;
            markConnected(grid, nx, ny);
        }
    }
}

