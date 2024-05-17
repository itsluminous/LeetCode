public class Solution {
    public void SetZeroes(int[][] matrix) {
        int r = matrix.Length, c = matrix[0].Length;
        bool[] rows = new bool[r], cols = new bool[c];

        // mark all rows & cols that need to be changed
        for(var i=0; i<r; i++)
            for(var j=0; j<c; j++)
                if(matrix[i][j] == 0)
                    rows[i] = cols[j] = true;

        // change all cols for a row
        for(var i=0; i<r; i++)
            if(rows[i])
                for(var j=0; j<c; j++) matrix[i][j] = 0;

        // change all rows for a col
        for(var i=0; i<c; i++)
            if(cols[i])
                for(var j=0; j<r; j++) matrix[j][i] = 0;
    }
}