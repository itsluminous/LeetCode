public class Solution {
    private static int UNGUARDED = 0, GUARDED = 1, GUARD = 2, WALL = 3;

    public int CountUnguarded(int m, int n, int[][] guards, int[][] walls) {
        // initialize grid with guards and walls
        var grid = new int[m,n];
        foreach(var g in guards) grid[g[0],g[1]] = GUARD;
        foreach(var w in walls) grid[w[0],w[1]] = WALL;

        // for every guard, mark cells in all directions as guarded
        foreach(var g in guards) MarkGuarded(g[0], g[1], grid, m, n);

        // count unguarded cells
        var count = 0;
        foreach(var cell in grid)
            if(cell == UNGUARDED) count++;
        
        return count;
        
    }

    private void MarkGuarded(int row, int col, int[,] grid, int m, int n){
        // mark upwards
        for(var r=row-1; r>=0; r--){
            if(grid[r,col] == WALL || grid[r,col] == GUARD) break;
            grid[r,col] = GUARDED;
        }

        // mark downwards
        for (var r = row + 1; r < m; r++) {
            if (grid[r,col] == WALL || grid[r,col] == GUARD) break;
            grid[r,col] = GUARDED;
        }

        // mark leftwards
        for (var c = col - 1; c >= 0; c--) {
            if (grid[row,c] == WALL || grid[row,c] == GUARD) break;
            grid[row,c] = GUARDED;
        }

        // mark rightwards
        for (var c = col + 1; c < n; c++) {
            if (grid[row,c] == WALL || grid[row,c] == GUARD) break;
            grid[row,c] = GUARDED;
        }
    }
}