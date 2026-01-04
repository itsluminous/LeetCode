class Solution {
    public int latestDayToCross(int row, int col, int[][] cells) {
        // linearly checking all days gives TLE, so binary search
        int left = 1, right = cells.length, ans = 0;
        while(left <= right){
            var mid = left + (right - left) / 2;
            if(canWalk(row, col, cells, mid)){
                ans = mid;
                left = mid+1;
            }
            else
                right = mid-1;
        }
        return ans;
    }

    private boolean canWalk(int row, int col, int[][] cells, int day){
        var visited = new boolean[row][col];
        for(var d=0; d<day; d++) visited[cells[d][0]-1][cells[d][1]-1] = true;  // mark all sea as visited

        Queue<int[]> queue = new LinkedList<>();
        // add unvisited starting cols in queue
        for(var c=0; c<col; c++){
            if(visited[0][c]) continue;
            visited[0][c] = true;
            queue.offer(new int[]{0, c});
        }

        int[][] dirs = {{0, 1}, {0, -1}, {1, 0}, {-1, 0}};
        while(!queue.isEmpty()){
            var cell = queue.poll();
            int r = cell[0], c = cell[1];
            if(r == row-1) return true; // reached bottom
            
            for(var dir : dirs){
                int dr = dir[0], dc = dir[1];
                int nr = r + dr, nc = c + dc;
                if(nr == -1 || nc == -1 || nr == row || nc == col || visited[nr][nc]) continue;

                visited[nr][nc] = true;
                queue.offer(new int[]{nr, nc});
            }
        }

        return false;
    }
}