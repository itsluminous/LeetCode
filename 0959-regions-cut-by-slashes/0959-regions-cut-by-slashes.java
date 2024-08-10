// idea is to upscale the given grid so that problem is now to count number of islands in matrix
// refer https://leetcode.com/problems/regions-cut-by-slashes/solutions/205674/dfs-on-upscaled-grid/
class Solution {
    public int regionsBySlashes(String[] grid) {
        var n = grid.length;

        var matrix = upscale(grid);
        var regions = 0;
        for(var i=0; i<n*3; i++)
            for(var j=0; j<n*3; j++)
                regions += dfs(matrix, i, j);
        
        return regions;
    }

    // dfs to count number of islands
    private int dfs(int[][] matrix, int i, int j){
        var n = matrix.length;
        if(i == -1 || j == -1 || i == n || j == n || matrix[i][j] == 1) return 0;

        matrix[i][j] = 1;
        dfs(matrix, i-1, j);
        dfs(matrix, i+1, j);
        dfs(matrix, i, j-1);
        dfs(matrix, i, j+1);
        return 1;
    }

    // convert each cell into a matrix of 3x3
    private int[][] upscale(String[] grid){
        var n = grid.length;
        var matrix = new int[n*3][n*3];

        for(var i=0; i<n; i++){
            for(var j=0; j<n; j++){
                if(grid[i].charAt(j) == '/')
                    setOne(matrix, i*3, j*3, false);
                else if(grid[i].charAt(j) == '\\')
                    setOne(matrix, i*3, j*3, true);
            }
        }

        return matrix;
    }

    private void setOne(int[][] matrix, int i, int j, boolean leftToRight){
        matrix[i+1][j+1] = 1;
        
        if(leftToRight)
            matrix[i][j] = matrix[i+2][j+2] = 1;
        else
            matrix[i][j+2] = matrix[i+2][j] = 1;
    }
}