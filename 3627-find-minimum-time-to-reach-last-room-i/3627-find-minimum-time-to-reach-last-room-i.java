class Solution {
    public int minTimeToReach(int[][] moveTime) {
        int m = moveTime.length, n = moveTime[0].length;
        int[][] dirs = {{0, 1}, {0, -1}, {1, 0}, {-1, 0}};

        var visited = new boolean[m*n];
        var pq = new PriorityQueue<int[]>((a,b) -> a[0] - b[0]);
        pq.offer(new int[]{0, 0, 0});   // [time, x, y]

        while(!pq.isEmpty()){
            var val = pq.poll();
            int tick = val[0], x = val[1], y = val[2];
            var visIdx = x * n + y;

            if(visited[visIdx]) continue;
            visited[visIdx] = true;
            for(var dir : dirs){
                int dx = dir[0], dy = dir[1];
                int nx = x + dx, ny = y + dy;
                if(nx == -1 || ny == -1 || nx == m || ny == n || visited[nx * n + ny]) continue;
                
                var maxTick = 1 + Math.max(tick, moveTime[nx][ny]);
                if(nx == m-1 && ny == n-1) return maxTick;
                pq.offer(new int[]{maxTick, nx, ny});
            }
        }

        return -1;
    }
}