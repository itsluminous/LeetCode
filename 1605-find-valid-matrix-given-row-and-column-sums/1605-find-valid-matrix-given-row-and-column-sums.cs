public class Solution {
    public int[][] RestoreMatrix(int[] rowSum, int[] colSum) {
        int m = rowSum.Length, n = colSum.Length;
        var ans = new int[m][];
        for(var i=0; i<m; i++) ans[i] = new int[n];

        for(var i=0; i<m; i++){
            for(var j=0; j<n; j++){
                ans[i][j] = Math.Min(rowSum[i], colSum[j]);
                rowSum[i] -= ans[i][j];
                colSum[j] -= ans[i][j];
            }
        }

        return ans;
    }
}