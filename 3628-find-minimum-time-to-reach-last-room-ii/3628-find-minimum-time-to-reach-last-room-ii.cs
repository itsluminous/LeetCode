public class Solution {
    public int MinTimeToReach(int[][] moveTime) {
        int m = moveTime.Length, n = moveTime[0].Length;
        (int, int)[] dirs = [(0, 1), (0, -1), (1, 0), (-1, 0)];

        var minTime = new int[m * n];
        var pq = new PriorityQueue<int[], int>();
        pq.Enqueue([0, 0, 0, 0], 0);  // [time, extra, x, y] => extra = 1 if next step needs 2 secs

        while (pq.Count > 0) {
            var val = pq.Dequeue();
            int tick = val[0], extra = val[1], x = val[2], y = val[3];
            var minTimeIdx = x * n + y;

            if(!(x == 0 && y == 0) && minTime[minTimeIdx] > 0) continue;    // already processed with better time
            if(x == m - 1 && y == n - 1) return tick;                       // found destination
            minTime[minTimeIdx] = tick;

            foreach(var (dx, dy) in dirs){
                int nx = x + dx, ny = y + dy;
                if(nx == -1 || ny == -1 || nx == m || ny == n) continue;    // out of bounds

                var nextTick = 1 + extra + Math.Max(tick, moveTime[nx][ny]);
                var nextIdx = nx * n + ny;
                if(minTime[nextIdx] > 0 && minTime[nextIdx] <= nextTick) continue;
                pq.Enqueue([nextTick, 1 - extra, nx, ny], nextTick);
            }
        }

        return -1;
    }
}