class Solution {
    public int minimumEffortPath(int[][] heights) {
        int m = heights.length, n = heights[0].length;
        
        var effort = new int[m][n];
        for(var i=0; i<m; i++) Arrays.fill(effort[i], Integer.MAX_VALUE);
        effort[0][0] = 0;

        var queue = new PriorityQueue<int[]>((p1, p2) -> p1[2] - p2[2]);
        queue.offer(new int[]{0, 0, 0});    // x, y, effort

        int[][] dirs = {{0, 1}, {0, -1}, {1, 0}, {-1, 0}};

        while(!queue.isEmpty()){
            var curr = queue.poll();
            int x = curr[0], y = curr[1], efrt = curr[2];
            if(x == m-1 && y == n-1) return effort[x][y];
            if(effort[x][y] < efrt) continue;   // we found a better route already

            for(var dir : dirs){
                int nx = x + dir[0], ny = y + dir[1];
                if(nx == -1 || ny == -1 || nx == m || ny == n) continue;    // out of bounds
                if(effort[nx][ny] <= Math.max(efrt, Math.abs(heights[x][y] - heights[nx][ny]))) continue;

                effort[nx][ny] = Math.max(efrt, Math.abs(heights[x][y] - heights[nx][ny]));
                queue.offer(new int[]{nx, ny, effort[nx][ny]});
            }
        }

        return 0;
    }
}