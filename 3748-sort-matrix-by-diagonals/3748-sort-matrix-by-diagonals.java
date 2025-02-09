class Solution {
    public int[][] sortMatrix(int[][] grid) {
        var n = grid.length;

        // upper right diagonal
        for(var k=n-1; k>0; k--){
            var nums = new ArrayList<Integer>();
            for(int i=0, j=k; j<n; j++, i++){
                nums.add(grid[i][j]);
            }
            Collections.sort(nums);
            var idx=0;
            for(int j=k, i=0; j<n; j++, i++){
                grid[i][j] = nums.get(idx++);
            }
        }

        // lower left diagonal
        for(var k=0; k<n; k++){
            var nums = new ArrayList<Integer>();
            for(int i=k, j=0; j<n-k; i++, j++){
                nums.add(grid[i][j]);
            }
            Collections.sort(nums, Collections.reverseOrder());
            var idx=0;
            for(int i=k, j=0; j<n-k; i++, j++){
                grid[i][j] = nums.get(idx++);
            }
        }

        return grid;
    }
}