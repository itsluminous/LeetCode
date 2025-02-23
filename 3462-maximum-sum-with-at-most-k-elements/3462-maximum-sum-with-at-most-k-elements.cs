public class Solution {
    public long MaxSum(int[][] grid, int[] limits, int k) {
        // find all biggest numbers in each row, within limit
        var biggest = new List<int>();
        for(var i=0; i < grid.Length; i++){
            Array.Sort(grid[i], (a, b) => b - a);
            for(var j=0; j<limits[i]; j++)
                biggest.Add(grid[i][j]);
        }

        // pick top k numbers from biggest numbers
        biggest.Sort((a, b) => b - a);
        long ans = 0;
        for(var i=0; i<k; i++)
            ans += biggest[i];

        return ans;
    }
}