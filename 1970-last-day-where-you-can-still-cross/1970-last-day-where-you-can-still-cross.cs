public class Solution {
    public int LatestDayToCross(int row, int col, int[][] cells) {
        // linearly checking all days gives TLE, so binary search
        int left = 1, right = cells.Length, ans = 0;
        while(left <= right){
            var mid = left + (right - left) / 2;
            if(CanWalk(row, col, cells, mid)){
                ans = mid;
                left = mid+1;
            }
            else
                right = mid-1;
        }
        return ans;
    }

    private bool CanWalk(int row, int col, int[][] cells, int day){
        var visited = new bool[row, col];
        for(var d=0; d<day; d++) visited[cells[d][0]-1, cells[d][1]-1] = true;  // mark all sea as visited

        var queue = new Queue<(int, int)>();
        // add unvisited starting cols in queue
        for(var c=0; c<col; c++){
            if(visited[0, c]) continue;
            visited[0, c] = true;
            queue.Enqueue((0, c));
        }

        (int, int)[] dirs = [(0, 1), (0, -1), (1, 0), (-1, 0)];
        while(queue.Count > 0){
            var (r, c) = queue.Dequeue();
            if(r == row-1) return true; // reached bottom
            
            foreach(var (dr, dc) in dirs){
                int nr = r + dr, nc = c + dc;
                if(nr == -1 || nc == -1 || nr == row || nc == col || visited[nr, nc]) continue;

                visited[nr, nc] = true;
                queue.Enqueue((nr, nc));
            }
        }

        return false;
    }
}