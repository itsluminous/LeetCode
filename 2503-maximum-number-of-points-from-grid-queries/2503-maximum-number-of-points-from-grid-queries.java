class Solution {
    public int[] maxPoints(int[][] grid, int[] queries) {
        int m = grid.length, n = grid[0].length, k = queries.length;
        int[][] dirs = {{0, 1}, {0, -1}, {1, 0}, {-1, 0}};
        
        // sort the queries in asc order, while maintaining index
        var queryIdx = new int[k][2];
        for(var i=0; i<k; i++)
            queryIdx[i] = new int[]{queries[i], i};
        Arrays.sort(queryIdx, (q1, q2) -> q1[0] - q2[0]);

        // create a min heap for processing smaller numbers in grid first
        var pq = new PriorityQueue<int[]>((a, b) -> a[0] - b[0]);   // [num, x, y]
        pq.offer(new int[]{grid[0][0], 0, 0});
        grid[0][0] = 0; // mark visited
        
        // time to find answer for queries
        var ans = new int[k];
        var count = 0;

        // Do BFS for each query, starting from smallest query
        for(var qi : queryIdx){
            int query = qi[0], idx = qi[1];
            
            // BFS
            while(!pq.isEmpty() && pq.peek()[0] < query){
                var val = pq.poll();
                int num = val[0], x = val[1], y = val[2];
                count++;

                for(var next : dirs){
                    int dx = next[0], dy = next[1];
                    int nx = x + dx, ny = y + dy;
                    if(nx == -1 || ny == -1 || nx == m || ny == n || grid[nx][ny] == 0) continue;
                    
                    pq.offer(new int[]{grid[nx][ny], nx, ny});
                    grid[nx][ny] = 0;   // mark visited
                }
            }

            ans[idx] = count;
        }

        return ans;
    }
}