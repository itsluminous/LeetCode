public class Solution {
    public int[][] SortMatrix(int[][] grid) {
        var n = grid.Length;

        // upper right diagonal
        for(var k=n-1; k>0; k--){
            var nums = new List<int>();
            for(int i=0, j=k; j<n; j++, i++){
                nums.Add(grid[i][j]);
            }
            nums.Sort();
            var idx=0;
            for(int j=k, i=0; j<n; j++, i++){
                grid[i][j] = nums[idx++];
            }
        }

        // lower left diagonal
        for(var k=0; k<n; k++){
            var nums = new List<int>();
            for(int i=k, j=0; j<n-k; i++, j++){
                nums.Add(grid[i][j]);
            }
            nums.Sort();
            var idx=nums.Count-1;
            for(int i=k, j=0; j<n-k; i++, j++){
                grid[i][j] = nums[idx--];
            }
            
        }

        return grid;
    }
}