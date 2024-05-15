class Solution {
    int[][] dirs;

    public int maximumSafenessFactor(List<List<Integer>> grid) {
        var n = grid.size();
        if(grid.get(0).get(0) == 1 || grid.get(n-1).get(n-1) == 1) return 0;

        dirs = new int[][]{{1, 0}, {-1, 0}, {0, 1}, {0, -1}};

        // find all thieves and distance from thieves
        Queue<int[]> queue = new LinkedList<>();    // queue to track thieves
        for(var i=0; i<n; i++)
            for(var j=0; j<n; j++)
                if(grid.get(i).get(j) == 1){
                    queue.offer(new int[]{i, j});
                    grid.get(i).set(j, 0);     // distance from thief is 0
                }
                else grid.get(i).set(j, -1);   // distance from thief is not yet calculated
        
        // use BFS to calculate distance of all non-thief cells from thieves
        var distance = 0;
        for(distance=0; queue.size() > 0; distance++){
            for(var i=queue.size(); i>0; i--){
                var pos = queue.poll();
                for(var dir : dirs){
                    int newX = pos[0] + dir[0], newY = pos[1] + dir[1];
                    if(isValid(grid, newX, newY) && grid.get(newX).get(newY) == -1){
                        grid.get(newX).set(newY, distance+1);
                        queue.offer(new int[]{newX, newY});
                    }   
                }
            }
        }

        // try to find path with max safeness factor
        // we try different safeness factors as target one by one, using binary search
        int left = 0, right = distance-1, ans = -1;
        while(left <= right){
            var mid = left + (right-left)/2;
            if(safenessFactorExists(grid, mid)){
                ans = mid;
                left = mid+1;
            }
            else
                right = mid-1;
        }

        return ans;
    }

    // start from cell (0,0) and try to reach last cell using BFS
    private boolean safenessFactorExists(List<List<Integer>> grid, int safenessFactor){
        if(grid.get(0).get(0) < safenessFactor) return false;

        var n = grid.size();
        var visited = new boolean[n][n];
        Queue<int[]> queue = new LinkedList<>();
        
        queue.offer(new int[]{0, 0});
        visited[0][0] = true;

        while(queue.size() > 0){
            for(var i=queue.size(); i>0; i--){
                var pos = queue.poll();
                if(pos[0] == n-1 && pos[1] == n-1) return true;     // reached last cell
                for(var dir : dirs){
                    int newX = pos[0] + dir[0], newY = pos[1] + dir[1];
                    if(isValid(grid, newX, newY) && !visited[newX][newY] && grid.get(newX).get(newY) >= safenessFactor){
                        queue.offer(new int[]{newX, newY});
                        visited[newX][newY] = true;
                    }
                }
            }
        }
        return false;
    }

    // check boundary conditions
    private boolean isValid(List<List<Integer>> grid, int x, int y){
        var n = grid.size();
        if(x == -1 || y == -1 || x == n || y == n) return false;
        return true;
    }

    // print grid for debugging
    private void printGrid(List<List<Integer>> grid){
        var n = grid.size();
        for(var i=0; i<n; i++){
            for(var j=0; j<n; j++){
                System.out.print(grid.get(i).get(j) + ", ");
            }
            System.out.println();
        }
    }
}