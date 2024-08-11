class Solution {
    public int minDays(int[][] grid) {
        var islands = countIslands(grid);
        if(islands != 1) return 0;  // already disconnected

        // make any cell as water and see if no. of islands changes
        for(var i=0; i<grid.length; i++){
            for(var j=0; j<grid[0].length; j++){
                if(grid[i][j] == 0) continue;

                grid[i][j] = 0; // make it water
                islands = countIslands(grid);
                if(islands != 1) return 1;
                grid[i][j] = 1; // make it land again
            }
        }

        // we can always split islands in max 2 days (imagine making any corner cell as one island)
        return 2;
    }

    private int countIslands(int[][] grid){
        int m = grid.length, n = grid[0].length;
        var visited = new boolean[m][n];
        var islands = 0;
        for(var i=0; i<m; i++){
            for(var j=0; j<n; j++){
                if(visited[i][j] || grid[i][j] == 0) continue;
                islands++;
                dfs(grid, visited, i, j);
            }
        }

        return islands;
    }

    private void dfs(int[][] grid, boolean[][] visited, int i, int j){
        int m = grid.length, n = grid[0].length;
        if(i == -1 || j == -1 || i == m || j == n || visited[i][j] || grid[i][j] == 0) return;

        visited[i][j] = true;
        dfs(grid, visited, i-1, j);
        dfs(grid, visited, i+1, j);
        dfs(grid, visited, i, j-1);
        dfs(grid, visited, i, j+1);
    }
}