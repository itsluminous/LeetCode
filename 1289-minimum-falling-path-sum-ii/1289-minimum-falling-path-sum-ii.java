// we need to know only the smallest two numbers in any row.
// one of them has to definitely be part of answer
public class Solution {
    public int minFallingPathSum(int[][] grid) {
        var n = grid.length;
        int small1 = 0, small2 = 0, smallpos = -1;
        for(var i=0; i<n; i++){
            int sm1 = Integer.MAX_VALUE, sm2 = Integer.MAX_VALUE, smpos = -1;
            for(var j=0; j<n; j++){
                var prevVal = (j == smallpos ? small2 : small1);    // pick the previous min value from different col

                if(prevVal + grid[i][j] < sm1){
                    sm2 = sm1;
                    sm1 = prevVal + grid[i][j];
                    smpos = j;
                }
                else
                    sm2 = Math.min(sm2, prevVal + grid[i][j]);
            }
            small1 = sm1; small2 = sm2; smallpos = smpos;
        }
        return small1;
    }
}