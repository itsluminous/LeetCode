class Solution {
    private static final int UNGUARDED = 0, GUARDED = 1, GUARD = 2, WALL = 3;

    public int countUnguarded(int m, int n, int[][] guards, int[][] walls) {
        // initialize grid with guards and walls
        var grid = new int[m][n];
        for(var g : guards) grid[g[0]][g[1]] = GUARD;
        for(var w : walls) grid[w[0]][w[1]] = WALL;

        // for every guard, mark cells in all directions as guarded
        for(var g : guards) markGuarded(g[0], g[1], grid);

        // count unguarded cells
        var count = 0;
        for(var row : grid)
            for(var cell : row)
                if(cell == UNGUARDED) count++;
        
        return count;
        
    }

    private void markGuarded(int row, int col, int[][] grid){
        // mark upwards
        for(var r=row-1; r>=0; r--){
            if(grid[r][col] == WALL || grid[r][col] == GUARD) break;
            grid[r][col] = GUARDED;
        }

        // mark downwards
        for (var r = row + 1; r < grid.length; r++) {
            if (grid[r][col] == WALL || grid[r][col] == GUARD) break;
            grid[r][col] = GUARDED;
        }

        // mark leftwards
        for (var c = col - 1; c >= 0; c--) {
            if (grid[row][c] == WALL || grid[row][c] == GUARD) break;
            grid[row][c] = GUARDED;
        }

        // mark rightwards
        for (var c = col + 1; c < grid[0].length; c++) {
            if (grid[row][c] == WALL || grid[row][c] == GUARD) break;
            grid[row][c] = GUARDED;
        }
    }
}