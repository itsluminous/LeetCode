class Solution {
    public int minTimeToReach(int[][] moveTime) {
        int m = moveTime.length, n = moveTime[0].length;
        int[][] dirs = {{0, 1}, {0, -1}, {1, 0}, {-1, 0}};

        var minTime = new int[m*n];
        var pq = new PriorityQueue<int[]>((a,b) -> a[0] - b[0]);
        pq.offer(new int[]{0, 0, 0, 0});   // [time, extra, x, y] => extra = 1 if next step needs 2 secs

        while(!pq.isEmpty()){
            var val = pq.poll();
            int tick = val[0], extra = val[1], x = val[2], y = val[3];
            var minTimeIdx = x * n + y;

            if(!(x == 0 && y == 0) && minTime[minTimeIdx] > 0) continue;    // already processed with better time
            if(x == m-1 && y == n-1) return tick;                           // found destination
            minTime[minTimeIdx] = tick;

            for(var dir : dirs){
                int dx = dir[0], dy = dir[1];
                int nx = x + dx, ny = y + dy;
                if(nx == -1 || ny == -1 || nx == m || ny == n) continue;    // out of bounds
                
                var nextTick = 1 + extra + Math.max(tick, moveTime[nx][ny]);
                if(minTime[nx * n + ny] > 0 && minTime[nx * n + ny] <= nextTick) continue;
                pq.offer(new int[]{nextTick, (1 - extra), nx, ny});
            }
        }

        return -1;  // unreachable
    }
}