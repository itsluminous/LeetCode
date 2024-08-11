public class Solution {
    public int MinDays(int[][] grid) {
        var islands = CountIslands(grid);
        if(islands != 1) return 0;  // already disconnected

        // make any cell as water and see if no. of islands changes
        for(var i=0; i<grid.Length; i++){
            for(var j=0; j<grid[0].Length; j++){
                if(grid[i][j] == 0) continue;

                grid[i][j] = 0; // make it water
                islands = CountIslands(grid);
                if(islands != 1) return 1;
                grid[i][j] = 1; // make it land again
            }
        }

        // we can always split islands in max 2 days (imagine making any corner cell as one island)
        return 2;
    }

    private int CountIslands(int[][] grid){
        int m = grid.Length, n = grid[0].Length;
        var visited = new bool[m,n];
        var islands = 0;
        for(var i=0; i<m; i++){
            for(var j=0; j<n; j++){
                if(visited[i,j] || grid[i][j] == 0) continue;
                islands++;
                DFS(grid, visited, i, j);
            }
        }

        return islands;
    }

    private void DFS(int[][] grid, bool[,] visited, int i, int j){
        int m = grid.Length, n = grid[0].Length;
        if(i == -1 || j == -1 || i == m || j == n || visited[i,j] || grid[i][j] == 0) return;

        visited[i,j] = true;
        DFS(grid, visited, i-1, j);
        DFS(grid, visited, i+1, j);
        DFS(grid, visited, i, j-1);
        DFS(grid, visited, i, j+1);
    }
}