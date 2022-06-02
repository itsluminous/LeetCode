public class Solution {
    public int[][] Transpose(int[][] matrix) {
        int m = matrix.Length, n = matrix[0].Length;
        var transpose = new int[n][];
        for(var i=0; i<n; i++) transpose[i] = new int[m];
        
        for(var i=0; i<n; i++)
            for(var j=0; j<m; j++)
                transpose[i][j] = matrix[j][i];
        
        return transpose;
    }
}