public class Solution {
    int[,] dp;

    public int MinScoreTriangulation(int[] values) {
        var n = values.Length;
        dp = new int[n,n];
        return DFS(values, 0, n-1);
    }

    private int DFS(int[] values, int i, int j){
        var res = int.MaxValue;
        if(dp[i,j] != 0) return dp[i,j];  // already calculated weight
        if(j-i < 2) return 0;               // triangle not possible

        // try all triangles with two points as i and j and 3rd between them
        // https://leetcode.com/problems/minimum-score-triangulation-of-polygon/solutions/286753/c-with-picture
        for(var k=i+1; k<j; k++){
            var curr = values[i] * values[j] * values[k];
            var left = DFS(values, i, k);
            var right = DFS(values, k, j);
            res = Math.Min(res, curr + left + right);
        }

        dp[i,j] = res;
        return res;
    }
}