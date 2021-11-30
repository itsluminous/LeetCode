// This is similar to #84. Largest rectangle in Histogram
// Refer : https://www.youtube.com/watch?v=dAVF2NpC3j4
public class Solution {
    public int MaximalRectangle(char[][] matrix) {
        if(matrix.Length == 0) return 0;
        
        int m = matrix.Length, n = matrix[0].Length, max = 0;
        int[] left = new int[n], right = new int[n], height = new int[n];
        for(var i=0; i<n; i++) right[i] = n;
        
        // loop through each row and find max rect area for histogram ending that row
        for(var i=0; i<m; i++){
            int curr_left = 0, curr_right = n;
            // Compute height of each histogram
            for(var j=0; j<n; j++){
                height[j] = matrix[i][j] == '0' ? 0 : ++height[j];
            }
            
            // Compute left of rectange that includes current col in full
            for(var j=0; j<n; j++){
                if(matrix[i][j] == '0'){
                    left[j] = 0;
                    curr_left = j+1;
                }
                else{
                    left[j] = Math.Max(left[j], curr_left);
                }
            }
            
            // Compute right of rectange that includes current col in full
            for(var j=n-1; j>=0; j--){
                if(matrix[i][j] == '0'){
                    right[j] = n;
                    curr_right = j;
                }
                else{
                    right[j] = Math.Min(right[j], curr_right);
                }
            }
            
            // Compute area of rectangle that includes current histogram bar in full
            for(var j=0; j<n; j++){
                var currArea = (right[j]-left[j]) * height[j];
                max = Math.Max(max, currArea);
            }
        }
        
        return max;
    }
}