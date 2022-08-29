public class Solution {
    public int NumIslands(char[][] grid) {
        int m = grid.Length, n=grid[0].Length, island=0;
        
        var visited = new bool[m][];
        for(int i=0; i<m; i++) visited[i] = new bool[n];
        
        for(int i=0; i<m; i++){
            for(int j=0; j<n; j++){
                if(grid[i][j] == '1' && !visited[i][j]){
                    island++;
                    Traverse(grid, visited, i,j, m, n);
                }
            }
        }
        
        return island;
    }
    
    private void Traverse(char[][] grid, bool[][] visited, int i, int j, int m, int n){
        if(i < 0 || j < 0 || i == m || j == n) return;  // out of bounds
        if(grid[i][j] == '0' || visited[i][j]) return;  // not valid points
        visited[i][j] = true;
        Traverse(grid, visited, i-1, j, m, n);
        Traverse(grid, visited, i+1, j, m, n);
        Traverse(grid, visited, i, j-1, m, n);
        Traverse(grid, visited, i, j+1, m, n);
    }
}