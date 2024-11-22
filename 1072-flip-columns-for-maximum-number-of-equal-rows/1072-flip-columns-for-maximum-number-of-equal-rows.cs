public class Solution {
    public int MaxEqualRowsAfterFlips(int[][] matrix) {
        int m = matrix.Length, n = matrix[0].Length, ans = 0;

        // count how many rows have same or exact opposite bits
        // we check opposites because after flipping, if curr row is 1111, then the opposite will be 0000
        for(var i=0; i<m; i++){
            // flipped value for curr row
            var flip = new int[n];
            for(var j=0; j<n; j++)  flip[j] = 1 - matrix[i][j];

            var curr = 1;
            for(var j=i+1; j<m; j++)
                if(matrix[j].SequenceEqual(matrix[i]) || matrix[j].SequenceEqual(flip))
                    curr++;
            
            ans = Math.Max(ans, curr);
        }

        return ans;
    }
}