class Solution {
    int maxGold = 0;
    int m = 0, n = 0;

    public int getMaximumGold(int[][] grid) {
        m = grid.length;
        n = grid[0].length;
        for(var i=0; i<m; i++)
            for(var j=0; j<n; j++)
                if(isValid(grid, i, j)) getMaximumGold(grid, 0, i, j);
        
        return maxGold;
    }

    private void getMaximumGold(int[][] grid, int gold, int x, int y){
        // check if this is the max gold
        gold += grid[x][y];
        maxGold = Math.max(maxGold, gold);

        // mark current cell as visited
        var val = grid[x][y];
        grid[x][y] = 0;

        // now try to go in all four directions
        if(isValid(grid, x+1, y)) getMaximumGold(grid, gold, x+1, y);
        if(isValid(grid, x-1, y)) getMaximumGold(grid, gold, x-1, y);
        if(isValid(grid, x, y+1)) getMaximumGold(grid, gold, x, y+1);
        if(isValid(grid, x, y-1)) getMaximumGold(grid, gold, x, y-1);

        // revert changes
        grid[x][y] = val;
    }

    private boolean isValid(int[][] grid, int x, int y){
        if(x == -1 || y == -1 || x == m || y == n) return false;  // out of bound
        if(grid[x][y] == 0) return false;     // already visited or no gold
        return true;
    }
}