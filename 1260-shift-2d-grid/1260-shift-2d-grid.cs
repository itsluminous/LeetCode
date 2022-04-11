public class Solution {
    public IList<IList<int>> ShiftGrid(int[][] grid, int k) {
        int c=grid.Length, r=grid[0].Length, n = c*r;
        k %= n;
        var result = new List<IList<int>>();
        var start = n - k;
        for (var i = start; i < n + start; i++) {
            int j = i % n, row = j / r, col = j % r;
            // move to next row if all cols are full
            if ((i - start) % r == 0)
                result.Add(new List<int>());
            result[result.Count-1].Add(grid[row][col]);
        }
        
        return result;
    }
}