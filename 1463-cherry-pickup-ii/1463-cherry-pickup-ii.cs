public class Solution {
    Dictionary<string,int> dp;  // for given robot pos what is max possible
    public int CherryPickup(int[][] grid) {
        dp = new Dictionary<string,int>();
        var cols = grid[0].Length;
        return CherryPickup(grid, 0, 0, cols-1);
    }
    
    public int CherryPickup(int[][] grid, int x, int r1y, int r2y) {
        // check for out of bounds
        int m = grid.Length, n = grid[0].Length;
        if(x < 0 || x == m || r1y < 0 || r1y == n || r2y < 0 || r2y == n)
            return 0;
        
        // check if we already faced this situation
        if(dp.ContainsKey($"{x}-{r1y}-{r2y}"))
            return dp[$"{x}-{r1y}-{r2y}"];
        
        // add current cherry value (if both robots are at same point, add it only once)
        var val = grid[x][r1y];
        if(r1y != r2y) val += grid[x][r2y];
        
        // try next 9 possible paths now
        var max = 0;
        for(var r1y_new = r1y-1; r1y_new <= r1y + 1; r1y_new++)
            for(var r2y_new = r2y-1; r2y_new <= r2y + 1; r2y_new++)
                max = Math.Max(max, CherryPickup(grid, x+1, r1y_new, r2y_new));
       
        val += max;
        
        // save the value of path with max benefit and return
        dp[$"{x}-{r1y}-{r2y}"] = val;
        dp[$"{x}-{r2y}-{r1y}"] = val;
        return val;
    }
}