public class Solution {
    public int MinTimeToReach(int[][] moveTime) {
        int m = moveTime.Length, n = moveTime[0].Length;
        (int, int)[] dirs = [(0, 1), (0, -1), (1, 0), (-1, 0)];

        var visited = new bool[m * n];
        var pq = new PriorityQueue<int[], int>();
        pq.Enqueue(new int[] {0, 0, 0}, 0); // [time, x, y]

        while(pq.Count > 0) {
            var val = pq.Dequeue();
            int tick = val[0], x = val[1], y = val[2];
            var visIdx = x * n + y;

            if(visited[visIdx]) continue;
            visited[visIdx] = true;

            foreach(var (dx, dy) in dirs){
                int nx = x + dx, ny = y + dy;
                if (nx < 0 || ny < 0 || nx >= m || ny >= n || visited[nx * n + ny]) continue;

                var maxTick = 1 + Math.Max(tick, moveTime[nx][ny]);
                if (nx == m - 1 && ny == n - 1) return maxTick;
                pq.Enqueue(new int[] {maxTick, nx, ny}, maxTick);
            }
        }

        return -1;
    }
}