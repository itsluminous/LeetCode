class Solution {
    public int numIslands(char[][] grid) {
        int m = grid.length, n = grid[0].length, count = 0;
        for(var i=0; i<m; i++)
            for(var j=0; j<n; j++)
                if(grid[i][j] == '1'){
                    count++;
                    dfs(grid, i, j);
                }
        
        return count;
    }

    private void dfs(char[][] grid, int x, int y){
        int m = grid.length, n = grid[0].length;
        if(x == -1 || y == -1 || x == m || y == n) return;  // out of bound
        if(grid[x][y] == '0') return;   // already visited or not land
        grid[x][y] = '0';   // mark visited

        // now travel in all four directions
        dfs(grid, x-1, y);
        dfs(grid, x+1, y);
        dfs(grid, x, y-1);
        dfs(grid, x, y+1);
    }
}