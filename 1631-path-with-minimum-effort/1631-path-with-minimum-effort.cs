// Dijkstra's algo for shortest path in graph
public class Solution {
    public int MinimumEffortPath(int[][] heights) {
        int m = heights.Length, n = heights[0].Length;
        
        // min Effort to reach a point
        var minEffort = new int[m,n];
        for(var i=0; i<m; i++)
            for(var j=0; j<n; j++)
                minEffort[i,j] = int.MaxValue;
        
        // start Dijkstra's algo
        var dir = new int[]{0, 1, 0, -1, 0};
        var pq = new PriorityQueue<int[], int>();   // pq so that next link that we pick is always shortest
        pq.Enqueue(new []{0,0,0}, 0);   // distance, row, col
        
        while(pq.Count > 0){
            var prev = pq.Dequeue();
            int dist = prev[0], r = prev[1], c = prev[2];
            if(dist > minEffort[r,c]) continue;
            if (r == m-1 && c == n-1) return dist; // Reach to bottom right
            
            for (int i = 0; i < 4; i++) {
                int row = r + dir[i], col = c + dir[i + 1];       // next row and col
                if(row<0 || row==m || col<0 || col==n) continue;  // out of bounds
                var newDist = Math.Max(dist, Math.Abs(heights[row][col] - heights[r][c]));
                if (minEffort[row,col] > newDist) {
                    minEffort[row,col] = newDist;
                    pq.Enqueue(new []{minEffort[row,col], row, col}, minEffort[row,col]);
                }
            }
        }
        
        return 0; // Unreachable code, C# require to return interger value.
    }
}

// TLE - Using DFS
// TLE example : [[8,3,2,5,2,10,7,1,8,9],[1,4,9,1,10,2,4,10,3,5],[4,10,10,3,6,1,3,9,8,8],[4,4,6,10,10,10,2,10,8,8],[9,10,2,4,1,2,2,6,5,7],[2,9,2,6,1,4,7,6,10,9],[8,8,2,10,8,2,3,9,5,3],[2,10,9,3,5,1,7,4,5,6],[2,3,9,2,5,10,2,7,1,8],[9,10,4,10,7,4,9,3,1,6]]
public class Solution1 {
    int minResult = int.MaxValue;
    
    public int MinimumEffortPath(int[][] heights) {
        int m = heights.Length, n = heights[0].Length;
        var visited = new bool[m,n];    // to ensure same step is not repeated in path
        var minEffort = new int[m,n];   // min Effort to reach a point
        
        for(var i=0; i<m; i++){
            for(var j=0; j<n; j++){
                minEffort[i,j] = int.MaxValue;
            }
        }
        minEffort[0,0] = 0;
        
        DFS(heights, minEffort, visited, 0, 0, 0, heights[0][0]);
        return minResult;
    }
    
    private void DFS(int[][] heights, int[,] minEffort, bool[,] visited, int minEffortTillNow, int i, int j, int prev){
        int m = heights.Length, n = heights[0].Length;
        
        // out of bounds
        if(i<0 || i==m || j<0 || j==n || visited[i,j]) return;
        // recalculate min effort in this path
        minEffortTillNow = Math.Max(minEffortTillNow, Math.Abs(heights[i][j]-prev));
        // if the curr point already has better path, then stop
        if(minEffort[i,j] < minEffortTillNow) return;
        // if reached destination, then update result
        if(i == m-1 && j == n-1){
            minResult = Math.Min(minResult, minEffortTillNow);
            return;
        }
        
        // look for next number in path
        minEffort[i,j] = minEffortTillNow;
        visited[i,j] = true;
        DFS(heights, minEffort, visited, minEffortTillNow, i+1, j, heights[i][j]);
        DFS(heights, minEffort, visited, minEffortTillNow, i-1, j, heights[i][j]);
        DFS(heights, minEffort, visited, minEffortTillNow, i, j+1, heights[i][j]);
        DFS(heights, minEffort, visited, minEffortTillNow, i, j-1, heights[i][j]);
        visited[i,j] = false;
    }
}