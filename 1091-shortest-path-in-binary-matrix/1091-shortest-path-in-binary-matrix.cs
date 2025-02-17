public class Solution {
    public int ShortestPathBinaryMatrix(int[][] grid) {
        var n = grid.Length;
        if(grid[0][0] == 1 || grid[n-1][n-1] == 1) return -1;

        var queue = new Queue<int[]>();
        queue.Enqueue([0, 0]);

        (int, int)[] dirs = [(0, 1), (1, 1), (1, 0), (1, -1), (0, -1), (-1, -1), (-1, 0), (-1, 1)];

        for(var steps = 1; queue.Count > 0; steps++){
            for(var i=queue.Count; i>0 ;i--){
                var coord = queue.Dequeue();
                int x = coord[0], y = coord[1];
                if(x == n-1 && y == n-1) return steps;

                foreach(var (dx, dy) in dirs){
                    int nx = x + dx, ny = y + dy;
                    if(nx == -1 || ny == -1 || nx == n || ny == n || grid[nx][ny] == 1)
                        continue;
                    queue.Enqueue(new int[]{nx, ny});
                    grid[nx][ny] = 1;   // mark visited
                }
            }
        }
        
        return -1;
    }
}