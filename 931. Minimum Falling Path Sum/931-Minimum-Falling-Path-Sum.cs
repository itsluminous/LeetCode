public class Solution {
    public int MinFallingPathSum(int[][] matrix) {
        var n = matrix.Length;

        for(var r=1; r<n; r++){
            var curr = matrix[r];
            for(var i=0; i<n; i++)
                curr[i] = matrix[r][i] + GetMin(i,matrix[r-1]);
        }

        return matrix[n-1].Min();
    }

    private int GetMin(int idx, int[] arr){
        var n = arr.Length;
        var min = arr[idx];
        if(idx != 0) min = Math.Min(min, arr[idx-1]);
        if(idx != n-1) min = Math.Min(min, arr[idx+1]);
        return min;
    }
}