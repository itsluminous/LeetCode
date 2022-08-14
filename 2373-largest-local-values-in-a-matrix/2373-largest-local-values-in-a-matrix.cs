public class Solution {
    public int[][] LargestLocal(int[][] grid) {
        var n = grid.Length;
        var result = new int[n-2][];
        for(var i=0; i<n-2; i++) result[i] = new int[n-2];
        
        for(var i=1; i<=n-2; i++){
            for(var j=1; j<=n-2; j++){
                result[i-1][j-1] = LargestLocal(grid, i, j);
            }
        }
        
        return result;
    }
    
    public int LargestLocal(int[][] grid, int i, int j) {
        var nums = new int[9];
        nums[0] = grid[i-1][j-1]; nums[1] = grid[i][j-1]; nums[2] = grid[i+1][j-1];
        nums[3] = grid[i-1][j]; nums[4] = grid[i][j]; nums[5] = grid[i+1][j];
        nums[6] = grid[i-1][j+1]; nums[7] = grid[i][j+1]; nums[8] = grid[i+1][j+1];
        
        return nums.Max();
    }
}