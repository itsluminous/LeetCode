public class Solution {
    public int MinimumObstacles(int[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        
        // matrix to track how many steps it took to reach each point
        var obs = new int[m,n]; 
        for(var i=0; i<m; i++)
            for(var j=0; j<n; j++)
                obs[i,j] = 1_00_001;

        obs[0,0] = grid[0][0];  // if [0,0] is obstacle, then we need to remove 1 obstacle 

        // queue for BFS, to reach [m-1, n-1]
        var queue = new Queue<(int x, int y)>();
        queue.Enqueue((0, 0));

        while(queue.Count > 0) {
            var (x, y) = queue.Dequeue();
            // Up
            if(x > 0 && obs[x, y] + grid[x-1][y] < obs[x-1, y]) {
                obs[x-1, y] = obs[x, y] + grid[x-1][y];
                queue.Enqueue((x-1, y));
            }
            // Down
            if(x < m-1 && obs[x, y] + grid[x+1][y] < obs[x+1, y]) {
                obs[x+1, y] = obs[x, y] + grid[x+1][y];
                queue.Enqueue((x+1, y));
            }
            // Left
            if(y > 0 && obs[x, y] + grid[x][y-1] < obs[x, y-1]) {
                obs[x, y-1] = obs[x, y] + grid[x][y-1];
                queue.Enqueue((x, y-1));
            }
            // Right
            if(y < n-1 && obs[x, y] + grid[x][y+1] < obs[x, y+1]) {
                obs[x, y+1] = obs[x, y] + grid[x][y+1];
                queue.Enqueue((x, y+1));
            }
        }

        return obs[m-1,n-1];
    }
}