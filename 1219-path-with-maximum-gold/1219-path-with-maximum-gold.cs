public class Solution {
    int maxGold = 0;
    int m = 0, n = 0;

    public int GetMaximumGold(int[][] grid) {
        m = grid.Length;
        n = grid[0].Length;
        for(var i=0; i<m; i++)
            for(var j=0; j<n; j++)
                if(IsValid(grid, i, j)) GetMaximumGold(grid, 0, i, j);
        
        return maxGold;
    }

    private void GetMaximumGold(int[][] grid, int gold, int x, int y){
        // check if this is the max gold
        gold += grid[x][y];
        maxGold = Math.Max(maxGold, gold);

        // mark current cell as visited
        var val = grid[x][y];
        grid[x][y] = 0;

        // now try to go in all four directions
        if(IsValid(grid, x+1, y)) GetMaximumGold(grid, gold, x+1, y);
        if(IsValid(grid, x-1, y)) GetMaximumGold(grid, gold, x-1, y);
        if(IsValid(grid, x, y+1)) GetMaximumGold(grid, gold, x, y+1);
        if(IsValid(grid, x, y-1)) GetMaximumGold(grid, gold, x, y-1);

        // revert changes
        grid[x][y] = val;
    }

    private bool IsValid(int[][] grid, int x, int y){
        if(x == -1 || y == -1 || x == m || y == n) return false;  // out of bound
        if(grid[x][y] == 0) return false;     // already visited or no gold
        return true;
    }
}