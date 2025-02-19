class Solution {
    public int swimInWater(int[][] grid) {
        var n = grid.length;
        int[][] dirs = {{0, 1}, {0, -1}, {1, 0}, {-1, 0}};

        // x, y, timeNeeded - sorted by time needed
        var pq = new PriorityQueue<int[]>((a, b) -> a[2] - b[2]);
        pq.offer(new int[]{0, 0, grid[0][0]});
        grid[0][0] = -1;    // visited

        while(!pq.isEmpty()){
            var curr = pq.poll();
            int x = curr[0], y = curr[1], t = curr[2];
            if(x == n-1 && y == n-1) return t;

            for(var dir : dirs){
                int nx = x + dir[0], ny = y + dir[1];
                if(nx == -1 || ny == -1 || nx == n || ny == n || grid[nx][ny] == -1) continue;
                
                var tt = Math.max(t, grid[nx][ny]); // time needed to reach here
                pq.offer(new int[]{nx, ny, tt});
                grid[nx][ny] = -1;    // visited
            }
        }

        return 0;   // will never reach here
    }
}