public class Solution {
    public int[][] UpdateMatrix(int[][] mat) {
        int m = mat.Length, n = mat[0].Length, fresh = 0;
        var queue = new Queue<int[]>();
        
        for(var i=0; i<m; i++){
            for(var j=0; j<n; j++){
                if(mat[i][j] == 0)
                    queue.Enqueue([i, j]);
            }
        }

        var ans = new int[m][];
        for(var i=0; i<m; i++) ans[i] = new int[n];
        if(queue.Count == m * n) return ans;    // all are already 0
        
        (int, int)[] dirs = [(0, 1), (0, -1), (1, 0), (-1, 0)];
        for(var dist=1; queue.Count > 0; dist++){
            for(var i=queue.Count; i>0; i--){
                var point = queue.Dequeue();
                int x = point[0], y = point[1];

                foreach(var (dx, dy) in dirs){
                    int nx = x + dx, ny = y + dy;
                    if(nx == -1 || ny == -1 || nx == m || ny == n || mat[nx][ny] == 0) continue;
                    mat[nx][ny] = 0;
                    ans[nx][ny] = dist;
                    queue.Enqueue([nx, ny]);
                }
            }
        }

        return ans;
    }
}