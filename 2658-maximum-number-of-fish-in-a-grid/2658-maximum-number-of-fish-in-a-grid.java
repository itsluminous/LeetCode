class Solution {
    int[][] dirs = {{0, -1}, {0, 1}, {-1, 0}, {1, 0}};

    public int findMaxFish(int[][] grid) {
        int m = grid.length, n = grid[0].length;
        var visited = new boolean[m][n];
        var maxFish = 0;

        for(var i=0; i<m; i++){
            for(var j=0; j<n; j++){
                if(grid[i][j] == 0 || visited[i][j]) continue;
                maxFish = Math.max(maxFish, bfs(grid, visited, i, j));
            }
        }

        return maxFish;
    }

    private int bfs(int[][] grid, boolean[][] visited, int x, int y){
        int m = grid.length, n = grid[0].length;

        Queue<int[]> queue = new LinkedList<>();
        queue.offer(new int[]{x, y});
        visited[x][y] = true;
        var count = grid[x][y];

        while(!queue.isEmpty()){
            var cords = queue.poll();
            x = cords[0]; y = cords[1];
            for(var dir : dirs){
                int dx = dir[0], dy = dir[1];
                int xx = x + dx, yy = y + dy;
                if(xx == -1 || yy == -1 || xx == m || yy == n || grid[xx][yy] == 0 || visited[xx][yy]) continue;
                queue.offer(new int[]{xx, yy});
                visited[xx][yy] = true;
                count += grid[xx][yy];
            }
        }

        return count;
    }
}