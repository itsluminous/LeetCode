// sort of prefix sum
public class Solution {
    public int CountSquares(int[][] matrix) {
        var count = 0;
        for(var i=0; i<matrix.Length; i++){
            for(var j=0; j<matrix[0].Length; j++){
                if (matrix[i][j] > 0 && i > 0 && j > 0)
                    matrix[i][j] = 1 + Math.Min(matrix[i-1][j-1], Math.Min(matrix[i-1][j], matrix[i][j-1]));
                count += matrix[i][j];
            }
        }
        
        return count;
    }
}