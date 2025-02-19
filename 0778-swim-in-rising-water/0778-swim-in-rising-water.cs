public class Solution {
    public int SwimInWater(int[][] grid) {
        var n = grid.Length;
        (int, int)[] dirs = [(0, 1), (0, -1), (1, 0), (-1, 0)];

        var pq = new PriorityQueue<int[], int>();    // x, y, timeNeeded - sorted by time needed
        pq.Enqueue([0, 0, grid[0][0]], grid[0][0]);
        grid[0][0] = -1;    // visited

        while(pq.Count > 0){
            var curr = pq.Dequeue();
            int x = curr[0], y = curr[1], t = curr[2];
            if(x == n-1 && y == n-1) return t;

            foreach(var (dx, dy) in dirs){
                int nx = x + dx, ny = y + dy;
                if(nx == -1 || ny == -1 || nx == n || ny == n || grid[nx][ny] == -1) continue;
                
                var tt = Math.Max(t, grid[nx][ny]); // time needed to reach here
                pq.Enqueue([nx, ny, tt], tt);
                grid[nx][ny] = -1;    // visited
            }
        }

        return 0;   // will never reach here
    }
}