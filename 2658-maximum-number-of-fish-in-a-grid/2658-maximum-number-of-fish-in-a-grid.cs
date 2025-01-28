public class Solution {
    (int x, int y)[] dirs = new []{(0, -1), (0, 1), (-1, 0), (1, 0)};

    public int FindMaxFish(int[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        var visited = new bool[m,n];
        var maxFish = 0;

        for(var i=0; i<m; i++){
            for(var j=0; j<n; j++){
                if(grid[i][j] == 0 || visited[i,j]) continue;
                maxFish = Math.Max(maxFish, BFS(grid, visited, i, j));
            }
        }

        return maxFish;
    }

    private int BFS(int[][] grid, bool[,] visited, int x, int y){
        int m = grid.Length, n = grid[0].Length;

        var queue = new Queue<(int, int)>();
        queue.Enqueue((x, y));
        visited[x, y] = true;
        var count = grid[x][y];

        while(queue.Count > 0){
            (x, y) = queue.Dequeue();
            foreach(var (dx, dy) in dirs){
                int xx = x + dx, yy = y + dy;
                if(xx == -1 || yy == -1 || xx == m || yy == n || grid[xx][yy] == 0 || visited[xx,yy]) continue;
                queue.Enqueue((xx, yy));
                visited[xx, yy] = true;
                count += grid[xx][yy];
            }
        }

        return count;
    }
}