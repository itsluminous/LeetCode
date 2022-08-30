public class Solution {
    public void Rotate(int[][] matrix) {
        var n = matrix.Length;
        for(int i=0; i<(n+1)/2; i++){
            for(int j=0; j<n/2; j++){
                Swap(matrix, i, j, n);
            }
        }
    }
    
    private void Swap(int[][] matrix, int i, int j, int n){
        var temp = matrix[n-j-1][i];
        matrix[n-j-1][i] = matrix[n-i-1][n-j-1];
        matrix[n-i-1][n-j-1] = matrix[j][n-i-1];
        matrix[j][n-i-1] = matrix[i][j];
        matrix[i][j] = temp;
    }
}