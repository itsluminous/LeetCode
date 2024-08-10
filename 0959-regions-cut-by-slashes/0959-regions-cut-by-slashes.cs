// idea is to upscale the given grid so that problem is now to count number of islands in matrix
// refer https://leetcode.com/problems/regions-cut-by-slashes/solutions/205674/dfs-on-upscaled-grid/
public class Solution {
    public int RegionsBySlashes(string[] grid) {
        var n = grid.Length;

        var matrix = Upscale(grid);
        var regions = 0;
        for(var i=0; i<n*3; i++)
            for(var j=0; j<n*3; j++)
                regions += DFS(matrix, i, j);
        
        return regions;
    }

    // dfs to count number of islands
    private int DFS(int[,] matrix, int i, int j){
        var n = matrix.GetLength(0);
        if(i == -1 || j == -1 || i == n || j == n || matrix[i,j] == 1) return 0;

        matrix[i,j] = 1;
        DFS(matrix, i-1, j);
        DFS(matrix, i+1, j);
        DFS(matrix, i, j-1);
        DFS(matrix, i, j+1);
        return 1;
    }

    // convert each cell into a matrix of 3x3
    private int[,] Upscale(string[] grid){
        var n = grid.Length;
        var matrix = new int[n*3,n*3];

        for(var i=0; i<n; i++){
            for(var j=0; j<n; j++){
                if(grid[i][j] == '/')
                    SetOne(matrix, i*3, j*3, false);
                else if(grid[i][j] == '\\')
                    SetOne(matrix, i*3, j*3, true);
            }
        }

        return matrix;
    }

    private void SetOne(int[,] matrix, int i, int j, bool leftToRight){
        matrix[i+1,j+1] = 1;
        
        if(leftToRight)
            matrix[i,j] = matrix[i+2,j+2] = 1;
        else
            matrix[i,j+2] = matrix[i+2,j] = 1;
    }
}