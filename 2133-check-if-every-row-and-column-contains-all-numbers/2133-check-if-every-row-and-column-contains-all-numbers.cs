public class Solution {
    public bool CheckValid(int[][] matrix) {
        int n = matrix.Length;
        
        for(var i=0; i<n; i++){
            var foundCol = new bool[n+1];
            var foundRow = new bool[n+1];
            for(var j=0; j<n; j++){
                if(matrix[i][j] <= n) foundCol[matrix[i][j]] = true;
                if(matrix[j][i] <= n) foundRow[matrix[j][i]] = true;
            }
            
            // check if any number was missing in current row/col
            for(var x=1; x<=n; x++)
                if(!foundCol[x] || !foundRow[x]) return false;
        }
        
        return true;
    }
}