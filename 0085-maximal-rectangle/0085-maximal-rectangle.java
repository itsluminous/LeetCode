// this is basically same problem as #84
// for each row in matrix, create a histogram and then find largest area in histogram
// explaination video : https://www.youtube.com/watch?v=dAVF2NpC3j4
public class Solution {
    public int maximalRectangle(char[][] matrix) {
        int m = matrix.length, n = matrix[0].length;
        var max = 0;
        var heights = new int[n];

        for(var i=0; i<m; i++){
            for(var j=0; j<n; j++){
                if(matrix[i][j] == '0') heights[j] = 0;
                else heights[j] += 1;
            }
            var area = largestRectangleArea(heights);
            max = Math.max(max, area);
        }

        return max;
    }

    // function to find largest square in a histogram
    public int largestRectangleArea(int[] heights) {
        var n = heights.length;
        int[] leftLessIndex = new int[n], rightLessIndex = new int[n];
        leftLessIndex[0] = -1;
        rightLessIndex[n-1] = n;
        
        // for each bar, find the point on left where we get lesser sized bar
        for(var i=1; i<n; i++){
            var curr = i-1;
            while(curr >= 0 && heights[curr] >= heights[i])
                curr = leftLessIndex[curr];
            leftLessIndex[i] = curr;
        }
        
        // for each bar, find the point on right where we get lesser sized bar
        for(var i=n-2; i>=0; i--){
            var curr = i+1;
            while(curr < n && heights[curr] >= heights[i])
                curr = rightLessIndex[curr];
            rightLessIndex[i] = curr;
        }
        
        // now using this data, find max rectangle
        var max = 0;
        for(var i=0; i<n; i++){
            var area = heights[i] * (rightLessIndex[i] - leftLessIndex[i] - 1);
            max = Math.max(max, area);
        }
        
        return max;
    }
}