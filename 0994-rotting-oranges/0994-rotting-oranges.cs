public class Solution {
    public int OrangesRotting(int[][] grid) {
        int m = grid.Length, n = grid[0].Length, fresh = 0;
        var rottenIdx = new Queue<int[]>();
        
        for(var i=0; i<m; i++){
            for(var j=0; j<n; j++){
                if(grid[i][j] == 1)
                    fresh++;
                else if(grid[i][j] == 2)
                    rottenIdx.Enqueue([i, j]);
            }
        }

        if(fresh == 0) return 0;    // nothing is fresh
        if(rottenIdx.Count == 0) return -1;    // no rotten, no conversion possible
        
        (int, int)[] dirs = [(0, 1), (0, -1), (1, 0), (-1, 0)];
        for(var minute=1; rottenIdx.Count > 0; minute++){
            for(var i=rottenIdx.Count; i>0; i--){
                var point = rottenIdx.Dequeue();
                int x = point[0], y = point[1];

                foreach(var (dx, dy) in dirs){
                    int nx = x + dx, ny = y + dy;
                    if(nx == -1 || ny == -1 || nx == m || ny == n || grid[nx][ny] != 1) continue;
                    
                    fresh--;
                    grid[nx][ny] = 0;
                    rottenIdx.Enqueue([nx, ny]);
                }
            }
            if(fresh == 0) return minute;
        }

        return -1;
    }
}