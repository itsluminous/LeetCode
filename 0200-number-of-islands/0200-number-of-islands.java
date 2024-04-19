public class Solution {
    public int numIslands(char[][] grid) {
        int m = grid.length, n = grid[0].length, count = 0;
        for(var i=0; i<m; i++)
            for(var j=0; j<n; j++)
                if(grid[i][j] == '1'){
                    count++;
                    traverseIsland(grid, i, j);
                }
        
        return count;
    }

    // DFS
    private void traverseIsland(char[][] grid, int x, int y) {
        if(x == -1 || y == -1 || x == grid.length || y == grid[0].length || grid[x][y] == '0') return;
        grid[x][y] = '0';
        traverseIsland(grid, x-1, y);
        traverseIsland(grid, x+1, y);
        traverseIsland(grid, x, y-1);
        traverseIsland(grid, x, y+1);
    }
}