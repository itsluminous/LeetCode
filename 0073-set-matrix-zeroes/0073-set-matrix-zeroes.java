class Solution {
    public void setZeroes(int[][] matrix) {
        int r = matrix.length, c = matrix[0].length;
        boolean[] rows = new boolean[r], cols = new boolean[c];

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