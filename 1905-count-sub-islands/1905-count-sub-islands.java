// make all cells in grid2 as +2 of what they are
// so any overlapping cell will always be 3
// any empty cell will be 0 or 2
class Solution {
    public int countSubIslands(int[][] grid1, int[][] grid2) {
        int m = grid1.length, n = grid1[0].length;

        // grid1
        for(var i=0; i<m; i++)
            for(var j=0; j<n; j++)
                    dfs(grid1, grid2, i, j);

        // grid2
        var count = 0;
        for(var i=0; i<m; i++){
            for(var j=0; j<n; j++){
                if(grid2[i][j] == 3)
                    count += dfs2(grid2, i, j);
            }
        }

        return count;
    }

    private void dfs(int[][] grid1, int[][] grid2, int i, int j){
        int m = grid1.length, n = grid1[0].length;
        if(i == -1 || i == m || j == -1 || j == n || grid1[i][j] == 0) return;
        grid1[i][j] = 0;
        grid2[i][j] += 2;
        dfs(grid1, grid2, i-1, j);
        dfs(grid1, grid2, i+1, j);
        dfs(grid1, grid2, i, j-1);
        dfs(grid1, grid2, i, j+1);
    }

    private int dfs2(int[][] grid, int i, int j){
        int m = grid.length, n = grid[0].length;
        if(i == -1 || i == m || j == -1 || j == n || grid[i][j] == 0 || grid[i][j] == 2) return 1;

        var match = grid[i][j] == 3 ? 1 : 0;
        grid[i][j] = 0;

        match &= dfs2(grid, i-1, j);
        match &= dfs2(grid, i+1, j);
        match &= dfs2(grid, i, j-1);
        match &= dfs2(grid, i, j+1);

        return match;
    }
}