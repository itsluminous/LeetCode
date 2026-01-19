class Solution {
    public int maxSideLength(int[][] mat, int threshold) {
        int m = mat.length, n = mat[0].length;
        var pre = new int[m+1][n+1];
        for(var i=1; i<=m; i++)
            for(var j=1; j<=n; j++)
                pre[i][j] = pre[i-1][j] + pre[i][j-1] - pre[i-1][j-1] + mat[i-1][j-1];
        
        int maxAns = Math.min(m, n), ans = 0;
        for(var i=1; i<=m; i++){
            for(var j=1; j<=n; j++){
                // try all possible side lengths of square starting from i,j index
                for(var s=ans+1; s<=maxAns; s++){
                    if(i+s-1 <= m && j+s-1 <= n && isValidSq(pre, i, j, i+s-1, j+s-1, threshold)) ans++;
                    else break;
                }
            }
        }

        return ans;
    }

    private boolean isValidSq(int[][] pre, int x0, int y0, int x1, int y1, int threshold){
        return pre[x1][y1] - pre[x0-1][y1] - pre[x1][y0-1] + pre[x0-1][y0-1] <= threshold;
    }
}