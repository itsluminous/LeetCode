class Solution {
    int[][] dirs = new int[][]{{0, 0}, {0, 1}, {0, -1}, {1, 0}, {-1, 0}};

    public int minCost(int[][] grid) {
        int m = grid.length, n = grid[0].length;
        var pq = new PriorityQueue<int[]>(Comparator.comparingInt(a -> a[2]));

        // cost to reach any cell will be infinity initially
        var minCost = new int[m][n];
        for(var i = 0; i < m; i++)
            Arrays.fill(minCost[i], Integer.MAX_VALUE);

        // start with 0,0 cell
        pq.offer(new int[]{0, 0, 0});
        minCost[0][0] = 0;

        // keep trying till you reach last cell
        while (!pq.isEmpty()) {
            var curr = pq.poll();
            int x = curr[0], y = curr[1], cost = curr[2];
            if(minCost[x][y] != cost) continue;      // we processed some other permutation
            enqueueNext(pq, grid, x, y, minCost);
        }

        return minCost[m-1][n-1];
    }

    private void enqueueNext(PriorityQueue<int[]> pq, int[][] grid, int x, int y, int[][] minCost) {
        int m = grid.length, n = grid[0].length, d = grid[x][y];
        var cost = minCost[x][y];
        
        // try to reach cells in all 4 dirs
        for(var i=1; i<=4; i++){
            int xx = x + dirs[i][0], yy = y + dirs[i][1];
            if(xx < 0 || yy < 0 || xx == m || yy == n) continue;

            var newCost = d == i ? cost : cost+1;   // 1 extra cost to change dir
            if(minCost[xx][yy] <= newCost) continue;
            
            minCost[xx][yy] = newCost;
            pq.offer(new int[]{xx, yy, newCost});
        }
    }
}