public class Solution {
    public int NumIslands(char[][] grid) {
        int m = grid.Length, n = grid[0].Length, count = 0;
        for(var i=0; i<m; i++)
            for(var j=0; j<n; j++)
                if(grid[i][j] == '1'){
                    count++;
                    TraverseIsland(grid, i, j);
                }
        
        return count;
    }

    // DFS
    private void TraverseIsland(char[][] grid, int x, int y) {
        if(x == -1 || y == -1 || x == grid.Length || y == grid[0].Length || grid[x][y] == '0') return;
        grid[x][y] = '0';
        TraverseIsland(grid, x-1, y);
        TraverseIsland(grid, x+1, y);
        TraverseIsland(grid, x, y-1);
        TraverseIsland(grid, x, y+1);
    }
}