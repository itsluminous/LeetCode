public class Solution {
    public int IslandPerimeter(int[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        var per = 0;
        for(var i=0; i<m; i++){
            for (var j=0; j<n; j++){
                if(grid[i][j] == 1)
                    per += Perimeter(grid, i, j);
            }
        }

        return per;
    }

    private int Perimeter(int[][] grid, int x, int y){
        int m = grid.Length, n = grid[0].Length;
        var per = 0;
        if(x == 0 || grid[x-1][y] == 0) per++;
        if(x == m-1 || grid[x+1][y] == 0) per++;
        if(y == 0 || grid[x][y-1] == 0) per++;
        if(y == n-1 || grid[x][y+1] == 0) per++;

        return per;
    }
}