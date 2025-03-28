public class Solution {
    public int[] MaxPoints(int[][] grid, int[] queries) {
        int m = grid.Length, n = grid[0].Length, k = queries.Length;
        (int, int)[] dirs = [(0, 1), (0, -1), (1, 0), (-1, 0)];
        
        // sort the queries in asc order, while maintaining index
        var queryIdx = new int[k][];
        for(var i=0; i<k; i++)
            queryIdx[i] = [queries[i], i];
        Array.Sort(queryIdx, (q1, q2) => q1[0] - q2[0]);

        // create a min heap for processing smaller numbers in grid first
        var pq = new PriorityQueue<int[], int>();   // [num, x, y]
        pq.Enqueue([grid[0][0], 0, 0], grid[0][0]);
        grid[0][0] = 0; // mark visited
        
        // time to find answer for queries
        var ans = new int[k];
        var count = 0;

        // Do BFS for each query, starting from smallest query
        foreach(var qi in queryIdx){
            int query = qi[0], idx = qi[1];
            
            // BFS
            while(pq.Count > 0 && pq.Peek()[0] < query){
                var val = pq.Dequeue();
                int num = val[0], x = val[1], y = val[2];
                count++;

                foreach(var (dx, dy) in dirs){
                    int nx = x + dx, ny = y + dy;
                    if(nx == -1 || ny == -1 || nx == m || ny == n || grid[nx][ny] == 0) continue;
                    
                    pq.Enqueue([grid[nx][ny], nx, ny], grid[nx][ny]);
                    grid[nx][ny] = 0;   // mark visited
                }
            }

            ans[idx] = count;
        }

        return ans;
    }
}