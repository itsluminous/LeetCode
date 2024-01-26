public class Solution {
    public int FindPaths(int m, int n, int maxMove, int startRow, int startColumn) {
        const int MOD = 1_000_000_000 + 7;
        var dp = new int[m,n];
        dp[startRow,startColumn] = 1; // 1 way to reach the position where we start
        var moves = 0;

        for(var mv = 1; mv <= maxMove; mv++){
            var tmp = new int[m,n];
            for(var r=0; r<m; r++){
                for(var c=0; c<n; c++){
                    // if we reached some edge, increase count of possible moves
                    if(r == m-1) moves = (moves + dp[r,c]) % MOD;
                    if(c == n-1) moves = (moves + dp[r,c]) % MOD;
                    if(r == 0) moves = (moves + dp[r,c]) % MOD;
                    if(c == 0) moves = (moves + dp[r,c]) % MOD;

                    // update the possible path count in temp dp array
                    var fromTop = r > 0 ? dp[r-1, c] : 0;
                    var fromBottom = r < m-1 ? dp[r+1, c] : 0;
                    var fromLeft = c > 0 ? dp[r, c-1] : 0;
                    var fromRight = c < n-1 ? dp[r, c+1] : 0;
                    tmp[r,c] = (((fromTop + fromBottom) % MOD) + ((fromLeft + fromRight) % MOD)) % MOD;
                }
            }
            dp = tmp;
        }
        return moves;
    }
}