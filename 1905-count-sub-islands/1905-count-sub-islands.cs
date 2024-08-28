// make all cells in grid2 as +2 of what they are
// so any overlapping cell will always be 3
// any empty cell will be 0 or 2
public class Solution {
    public int CountSubIslands(int[][] grid1, int[][] grid2) {
        int m = grid1.Length, n = grid1[0].Length;

        // grid1
        for(var i=0; i<m; i++)
            for(var j=0; j<n; j++)
                    DFS(grid1, grid2, i, j);

        // grid2
        var count = 0;
        for(var i=0; i<m; i++){
            for(var j=0; j<n; j++){
                if(grid2[i][j] == 3)
                    count += DFS2(grid2, i, j);
            }
        }

        return count;
    }

    private void DFS(int[][] grid1, int[][] grid2, int i, int j){
        int m = grid1.Length, n = grid1[0].Length;
        if(i == -1 || i == m || j == -1 || j == n || grid1[i][j] == 0) return;
        grid1[i][j] = 0;
        grid2[i][j] += 2;
        DFS(grid1, grid2, i-1, j);
        DFS(grid1, grid2, i+1, j);
        DFS(grid1, grid2, i, j-1);
        DFS(grid1, grid2, i, j+1);
    }

    private int DFS2(int[][] grid, int i, int j){
        int m = grid.Length, n = grid[0].Length;
        if(i == -1 || i == m || j == -1 || j == n || grid[i][j] == 0 || grid[i][j] == 2) return 1;

        var match = grid[i][j] == 3 ? 1 : 0;
        grid[i][j] = 0;

        match &= DFS2(grid, i-1, j);
        match &= DFS2(grid, i+1, j);
        match &= DFS2(grid, i, j-1);
        match &= DFS2(grid, i, j+1);

        return match;
    }
}