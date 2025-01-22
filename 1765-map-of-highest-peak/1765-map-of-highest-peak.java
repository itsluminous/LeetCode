class Solution {
    public int[][] highestPeak(int[][] isWater) {
        int m = isWater.length, n = isWater[0].length;
        Queue<int[]> queue = new LinkedList<>();
        for(var i=0; i<m; i++)
            for(var j=0; j<n; j++)
                if(isWater[i][j] == 1){
                    queue.offer(new int[]{i, j});
                    isWater[i][j] = -1;     // set all water to -1 to differentiate it
                }
        
        var waters = new ArrayList<>(queue);
        int[][] dirs = {{0, -1}, {0, 1}, {-1, 0}, {1, 0}};
        
        for(var height = 1; !queue.isEmpty(); height++){
            for(var i=queue.size(); i>0; i--){
                var cell = queue.poll();
                int x = cell[0], y = cell[1];
                for(var dir : dirs){
                    int xx = x + dir[0], yy = y + dir[1];
                    if(xx == -1 || yy == -1 || xx == m || yy == n || isWater[xx][yy] != 0) continue;

                    queue.offer(new int[]{xx, yy});
                    isWater[xx][yy] = height;
                }
            }
        }

        // change all water from -1 to 0
        for(var cell : waters)
            isWater[cell[0]][cell[1]] = 0;
        
        return isWater;
    }
}