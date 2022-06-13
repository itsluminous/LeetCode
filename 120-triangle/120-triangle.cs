// Bottom up DP
public class Solution {
    public int MinimumTotal(IList<IList<int>> triangle) {
        var n = triangle.Count;
        var dp = new int[n+1];
        for(var row=n-1; row>=0; row--)
            for(var col=0; col<triangle[row].Count; col++)
                dp[col] = triangle[row][col] + Math.Min(dp[col], dp[col+1]);
        
        return dp[0];
    }
}