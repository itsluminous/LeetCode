class Solution {
    public int matrixScore(int[][] grid) {
        int m = grid.length, n = grid[0].length, halfRows = (m+1)/2;

        // row operation - make sure that we have 1st bit set (Most Significant Bit)
        // because `10000` is greater than `01111` in binary
        for(var i=0; i<m; i++){
            if(grid[i][0] == 1) continue;
            for(var j=0; j<n; j++) grid[i][j] ^= 1;  // flip the bit
        }

        // col operation - make sure that count of 1 in col is >= count of 0
        // exclude col-1 because we just now ensured that they are all 1
        for(var j=1; j<n; j++){
            var setBit = 0;
            for(var i=0; i<m; i++) setBit += grid[i][j];

            if(setBit >= halfRows) continue;
            for(var i=0; i<m; i++) grid[i][j] ^= 1;  // flip the bit
        }

        // calculate score of matrix
        var score = 0;
        for(var i=0; i<m; i++){
            var binStr = new StringBuilder();
            for(var j=0; j<n; j++) binStr.append(grid[i][j]);
            score += Integer.parseInt(binStr.toString(), 2);   // binary to decimal conversion
        }

        return score;
    }
}