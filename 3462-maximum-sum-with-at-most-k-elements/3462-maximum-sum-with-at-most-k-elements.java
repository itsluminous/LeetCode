class Solution {
    public long maxSum(int[][] grid, int[] limits, int k) {
        // find all biggest numbers in each row, within limit
        var biggest = new ArrayList<Integer>();
        for(var i=0; i < grid.length; i++){
            Arrays.sort(grid[i]);
            for(var j = grid[i].length-1; j >= grid[i].length - limits[i]; j--)
                biggest.add(grid[i][j]);
        }

        // pick top k numbers from biggest numbers
        Collections.sort(biggest, (a, b) -> b - a);
        long ans = 0;
        for(var i=0; i<k; i++)
            ans += biggest.get(i);

        return ans;
    }
}