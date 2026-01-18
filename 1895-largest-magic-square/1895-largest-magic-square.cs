public class Solution {
    public int LargestMagicSquare(int[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        int[,] rowsum = new int[m,n], colsum = new int[m,n];

        // prefix sum of rows
        for(var i=0; i<m; i++){
            rowsum[i,0] = grid[i][0];
            for(var j=1; j<n; j++)
                rowsum[i,j] = rowsum[i,j-1] + grid[i][j];
        }

        // prefix sum of cols
        for(var j=0; j<n; j++){
            colsum[0,j] = grid[0][j];
            for(var i=1; i<m; i++)
                colsum[i,j] = colsum[i-1,j] + grid[i][j];
        }

        // start checking all squares, starting from biggest edge
        for(var edge = Math.Min(m, n); edge >= 2; edge--){
            for(var i=0; i+edge <= m; i++){
                for(var j=0; j+edge <= n; j++){
                    var firstRowSum = rowsum[i,j+edge-1] - (j > 0 ? rowsum[i,j-1] : 0);
                    var match = true;   // to flag if any mismatch occurs

                    // check if all rows have the same sum as first row
                    for(var r=i+1; r<i+edge; r++){
                        if(rowsum[r,j+edge-1] - (j > 0 ? rowsum[r,j-1] : 0) != firstRowSum){
                            match = false;
                            break;
                        }
                    }
                    if(!match) continue;

                    // check if all cols have same sum as first row
                    for(var c = j; c < j + edge; c++){
                        if(colsum[i+edge-1,c] - (i > 0 ? colsum[i-1,c] : 0) != firstRowSum){
                            match = false;
                            break;
                        }
                    }
                    if(!match) continue;

                    // check diagonals
                    int d1 = 0, d2 = 0;
                    for(var d=0; d<edge; d++){
                        d1 += grid[i+d][j+d];   // top-left to bottom-right
                        d2 += grid[i+d][j+edge-1-d];
                    }
                    if(d1 == firstRowSum && d2 == firstRowSum) return edge;
                }
            }
        }
        return 1;   // single cell is always valid answer
    }
}