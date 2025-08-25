class Solution {
    public int[] findDiagonalOrder(int[][] mat) {
        int m = mat.length, n = mat[0].length;
        int r = 0, c = 0, d = 0;
        var ans = new int[m*n];

        int[][] dirs = {{-1, 1}, {1, -1}};

        for(var idx = 0; idx < m*n; idx++){
            ans[idx] = mat[r][c];
            var nr = r + dirs[d][0];
            var nc = c + dirs[d][1];

            if(nr == -1 || nc == -1 || nr == m || nc == n) {
                if(d == 0){ // going up
                    r += (c == n-1 ? 1 : 0);    // move row down
                    c += (c < n-1 ? 1 : 0);     // move col right
                }
                else {  // going down
                    c += (r == m-1 ? 1 : 0);    // move col right
                    r += (r < m-1 ? 1 : 0);     // move row down
                }

                d = 1 - d; // change dir
            }
            else {
                r = nr;
                c = nc;
            }
        }

        return ans;
    }
}