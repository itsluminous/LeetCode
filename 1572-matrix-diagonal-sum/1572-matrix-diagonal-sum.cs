public class Solution {
    public int DiagonalSum(int[][] mat) {
        int n = mat.Length-1, sum = 0;
        for(var i=0; i<=n; i++){
            sum += mat[i][i];   // primary diagonal : left-top to right-down
            sum += mat[i][n-i]; // secondary diagonal : right-top to left-down
        }

        // if total rows count is odd, then we counted center cell twice
        if((n & 1) == 0)
            sum -= mat[n/2][n/2];
        
        return sum;
    }
}