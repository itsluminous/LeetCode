class Solution {
    public int[][] updateMatrix(int[][] mat) {
        int m = mat.length, n = mat[0].length, fresh = 0;
        Queue<int[]> queue = new LinkedList<>();
        
        for(var i=0; i<m; i++){
            for(var j=0; j<n; j++){
                if(mat[i][j] == 0)
                    queue.offer(new int[]{i, j});
            }
        }

        var ans = new int[m][];
        for(var i=0; i<m; i++) ans[i] = new int[n];
        if(queue.size() == m * n) return ans;    // all are already 0
        
        int[][] dirs = {{0, 1}, {0, -1}, {1, 0}, {-1, 0}};
        for(var dist=1; !queue.isEmpty(); dist++){
            for(var i=queue.size(); i>0; i--){
                var point = queue.poll();
                int x = point[0], y = point[1];

                for(var dir : dirs){
                    int dx = dir[0], dy = dir[1];
                    int nx = x + dx, ny = y + dy;
                    if(nx == -1 || ny == -1 || nx == m || ny == n || mat[nx][ny] == 0) continue;
                    mat[nx][ny] = 0;
                    ans[nx][ny] = dist;
                    queue.offer(new int[]{nx, ny});
                }
            }
        }

        return ans;
    }
}