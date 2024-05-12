public class Solution {
    public int[][] LargestLocal(int[][] grid) {
        var n = grid.Length;
        var ans = new int[n-2][];
        for(var i=0; i<n-2; i++) ans[i] = new int[n-2];

        for(var i=1; i<n-1; i++)
            for(var j=1; j<n-1; j++)
                for(var x=-1; x <= 1; x++)
                    for(var y=-1; y <= 1; y++)
                        ans[i-1][j-1] = Math.Max(ans[i-1][j-1], grid[i+x][j+y]);
        return ans;
    }
}