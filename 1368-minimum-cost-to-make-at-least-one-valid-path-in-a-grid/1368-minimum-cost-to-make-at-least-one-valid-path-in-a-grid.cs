public class Solution {
    int[,] dirs = new int[,]{{ 0, 0 }, { 0, 1 }, { 0, -1 }, { 1, 0 }, { -1, 0 }};

    public int MinCost(int[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        var pq = new PriorityQueue<(int x, int y, int cost), int>();

        // cost to reach any cell will be infinity initially
        var minCost = new int[m,n];
        for(var i=0; i<m; i++)
            for(var j=0; j<n; j++)
                minCost[i,j] = int.MaxValue;

        // start with 0,0 cell
        pq.Enqueue((0, 0, 0), 0);
        minCost[0,0] = 0;

        // keep trying till you reach last cell
        while(pq.Count > 0){
            var (x,y, cost) = pq.Dequeue();
            if(minCost[x,y] != cost) continue;      // we processed some other permutation
            EnqueueNext(pq, grid, x, y, minCost);
        }

        return minCost[m-1, n-1];
    }

    private void EnqueueNext(PriorityQueue<(int x, int y, int cost), int> pq, int[][] grid, int x, int y, int[,] minCost){
        int m = grid.Length, n = grid[0].Length, d = grid[x][y];
        var cost = minCost[x,y];
        
        // try to reach cells in all 4 dirs
        for(var i=1; i<=4; i++){
            int xx = x + dirs[i,0], yy = y + dirs[i,1];
            if(xx < 0 || yy < 0 || xx == m || yy == n) continue;

            var newCost = d == i ? cost : cost+1;   // 1 extra cost to change dir
            if(minCost[xx,yy] <= newCost) continue;
            
            minCost[xx,yy] = newCost;
            pq.Enqueue((xx, yy, newCost), newCost);
        }
    }
}