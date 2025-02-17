class Solution {
    public int shortestPathBinaryMatrix(int[][] grid) {
        var n = grid.length;
        if(grid[0][0] == 1 || grid[n-1][n-1] == 1) return -1;

        Queue<int[]> queue = new LinkedList<>();
        queue.offer(new int[]{0, 0});

        int[][] dirs = {{0, 1}, {1, 1}, {1, 0}, {1, -1}, {0, -1}, {-1, -1}, {-1, 0}, {-1, 1}};

        for(var steps = 1; !queue.isEmpty(); steps++){
            for(var i=queue.size(); i>0 ;i--){
                var coord = queue.poll();
                int x = coord[0], y = coord[1];
                if(x == n-1 && y == n-1) return steps;

                for(var dir : dirs){
                    int nx = x + dir[0], ny = y + dir[1];
                    if(nx == -1 || ny == -1 || nx == n || ny == n || grid[nx][ny] == 1)
                        continue;
                    queue.offer(new int[]{nx, ny});
                    grid[nx][ny] = 1;   // mark visited
                }
            }
        }
        
        return -1;
    }
}