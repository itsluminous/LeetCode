public class Solution {
    public int MaxSumSubmatrix(int[][] matrix, int k) {
        int m = matrix.Length, n = matrix[0].Length;
        var prefSum = new int[m+1,n+1];     // m rows, n cols
        
        var result = int.MinValue;
        for(var i=0; i<m; i++){
            for(var j=0; j<n; j++){
                prefSum[i+1, j+1] = matrix[i][j] + prefSum[i+1,j] + prefSum[i,j+1] - prefSum[i,j];
                
                // check sum of all possible rectangles in range i and j
                // h = height of rect, w = width of rect
                for(var h = 0; h <= i; h++){
                    for(var w = 0; w <= j; w++){
                        var rectSum = prefSum[i+1,j+1] - prefSum[i+1,j-w] - prefSum[i-h, j+1] + prefSum[i-h, j-w];
                        if(rectSum == k) return k;  // found max height possible. exit early
                        if(rectSum < k) result = Math.Max(result, rectSum);
                    }
                }
            }
        }
        
        return result;
    }
}