public class Solution {
    public int MinimumTime(int[][] grid) {
        if (grid[0][1] > 1 && grid[1][0] > 1) return -1;    // can never move
        
        int m = grid.Length, n = grid[0].Length;
        var dirs = new (int, int)[]{(0, 1), (0, -1), (1, 0), (-1, 0)};
        var visited = new bool[m,n];

        // priority queue to track the next closest cell
        var pq = new PriorityQueue<(int sec, int x, int y), int>();
        pq.Enqueue((0, 0, 0), 0);  // 0 secs for [0, 0]

        while(pq.Count > 0){
            var (sec, x, y) = pq.Dequeue();
            if(x == m-1 && y == n-1) return sec;

            foreach(var (dx, dy) in dirs){
                int newx = x + dx, newy = y + dy;
                if(!IsValid(grid, visited, newx, newy)) continue;
                
                var wait = (grid[newx][newy] - sec) % 2 == 0 ? 1 : 0;   // we will be 1 sec late for even diff
                var elapsed = Math.Max(grid[newx][newy] + wait, sec + 1);
                pq.Enqueue((elapsed, newx, newy), elapsed);
            }
        }

        return -1;
    }

    private bool IsValid(int[][] grid, bool[,] visited, int x, int y){
        int m = grid.Length, n = grid[0].Length;
        if(x == -1 || y == -1) return false;
        if(x == m || y == n) return false;
        if(visited[x,y]) return false;

        visited[x,y] = true;
        return true;
    }
}

// TLE - BFS
public class SolutionBFS {
    public int MinimumTime(int[][] grid) {
        int m = grid.Length, n = grid[0].Length;

        var dirs = new (int, int)[]{(0, 1), (0, -1), (1, 0), (-1, 0)};

        // queue for BFS, to reach [m-1, n-1]
        var queue = new Queue<(int x, int y)>();
        queue.Enqueue((0, 0));

        for(var sec = 0; queue.Count > 0; sec++){
            var visited = new HashSet<string>();
            for(var i=queue.Count; i>0; i--){
                var (x, y) = queue.Dequeue();
                if(x == m-1 && y == n-1) return sec;
                foreach(var (dx, dy) in dirs){
                    int newx = x + dx, newy = y + dy;
                    if(!IsValid(grid, visited, newx, newy, sec+1)) continue;
                    queue.Enqueue((newx, newy));
                }
            }
        }

        return -1;
    }

    private bool IsValid(int[][] grid, HashSet<string> visited, int x, int y, int sec){
        int m = grid.Length, n = grid[0].Length;
        if(x < 0 || y < 0) return false;
        if(x == m || y == n) return false;
        if(grid[x][y] > sec) return false;
        if(visited.Contains($"{x}-{y}")) return false;
        
        visited.Add($"{x}-{y}");
        return true;
    }
}