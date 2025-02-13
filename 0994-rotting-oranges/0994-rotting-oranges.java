class Solution {
    public int orangesRotting(int[][] grid) {
        int m = grid.length, n = grid[0].length, fresh = 0;
        Queue<int[]> rottenIdx = new LinkedList<>();
        
        for(var i=0; i<m; i++){
            for(var j=0; j<n; j++){
                if(grid[i][j] == 1)
                    fresh++;
                else if(grid[i][j] == 2)
                    rottenIdx.offer(new int[]{i, j});
            }
        }

        if(fresh == 0) return 0;    // nothing is fresh
        if(rottenIdx.size() == 0) return -1;    // no rotten, no conversion possible
        
        int[][] dirs = {{0, 1}, {0, -1}, {1, 0}, {-1, 0}};
        for(var minute=1; !rottenIdx.isEmpty(); minute++){
            for(var i=rottenIdx.size(); i>0; i--){
                var point = rottenIdx.poll();
                int x = point[0], y = point[1];

                for(var dir : dirs){
                    int dx = dir[0], dy = dir[1];
                    int nx = x + dx, ny = y + dy;
                    if(nx == -1 || ny == -1 || nx == m || ny == n || grid[nx][ny] != 1) continue;
                    
                    fresh--;
                    grid[nx][ny] = 0;
                    rottenIdx.offer(new int[]{nx, ny});
                }
            }
            if(fresh == 0) return minute;
        }

        return -1;
    }
}