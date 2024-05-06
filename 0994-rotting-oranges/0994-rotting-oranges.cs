public class Solution {
    public int OrangesRotting(int[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        var queue = new Queue<(int, int)>();

        var oranges = 0;
        // fill this queue with all rotten oranges
        for(var i=0; i<m; i++){
            for(var j=0; j<n; j++){
                if(grid[i][j] > 0) oranges++;
                if(grid[i][j] == 2) queue.Enqueue((i, j));
            }
        }

        // no need to process if there are no oranges or rotten oranges
        if(oranges != 0 && queue.Count == 0) return -1;
        if(oranges == 0 || queue.Count == 0) return 0;

        // now start spreading the epidemic - BFS way
        var minute = -1;
        for(; queue.Count > 0; minute++){
            oranges -= queue.Count;
            for(var i=queue.Count; i>0; i--){
                var (x,y) = queue.Dequeue();
                if(x > 0 && grid[x-1][y] == 1) {
                    grid[x-1][y] = 2; 
                    queue.Enqueue((x-1, y));
                }
                if(x < m-1 && grid[x+1][y] == 1) {
                    grid[x+1][y] = 2;
                    queue.Enqueue((x+1, y));
                }
                if(y > 0 && grid[x][y-1] == 1) {
                    grid[x][y-1] = 2;
                    queue.Enqueue((x, y-1));
                }
                if(y < n-1 && grid[x][y+1] == 1) {
                    grid[x][y+1] = 2;
                    queue.Enqueue((x, y+1));
                }
            }
        }

        if(oranges > 0) return -1;
        return minute;
    }
}