class Solution {
    public int minimumTime(int[][] grid) {
        if (grid[0][1] > 1 && grid[1][0] > 1) return -1;    // can never move
        
        int m = grid.length, n = grid[0].length;
        int[][] dirs = {{1, 0}, {-1, 0}, {0, 1}, {0, -1}};
        var visited = new boolean[m][n];

        // priority queue to track the next closest cell
        var pq = new PriorityQueue<int[]>((a, b) -> a[0] - b[0]);
        pq.offer(new int[]{0, 0, 0});  // 0 secs for [0, 0]

        while(!pq.isEmpty()){
            var curr = pq.poll();
            int sec = curr[0], x = curr[1], y = curr[2];
            if(x == m-1 && y == n-1) return sec;

            for(var dir : dirs){
                int newx = x + dir[0], newy = y + dir[1];
                if(!isValid(grid, visited, newx, newy)) continue;
                
                var wait = (grid[newx][newy] - sec) % 2 == 0 ? 1 : 0;   // we will be 1 sec late for even diff
                var elapsed = Math.max(grid[newx][newy] + wait, sec + 1);
                pq.offer(new int[]{elapsed, newx, newy});
            }
        }

        return -1;
    }

    private boolean isValid(int[][] grid, boolean[][] visited, int x, int y){
        int m = grid.length, n = grid[0].length;
        if(x == -1 || y == -1) return false;
        if(x == m || y == n) return false;
        if(visited[x][y]) return false;

        visited[x][y] = true;
        return true;
    }
}