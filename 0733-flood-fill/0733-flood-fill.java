class Solution {
    public int[][] floodFill(int[][] image, int sr, int sc, int color) {
        if(image[sr][sc] == color) return image;

        int m = image.length, n = image[0].length;
        var orig = image[sr][sc];
        image[sr][sc] = color;

        Queue<int[]> queue = new LinkedList<>();
        queue.offer(new int[]{sr, sc});

        int[][] dirs = {{0, 1}, {0, -1}, {1, 0}, {-1, 0}};
        while(!queue.isEmpty()){
            var point = queue.poll();
            int x = point[0], y = point[1];
            for(var dir : dirs){
                int dx = dir[0], dy = dir[1];
                int nx = x + dx, ny = y + dy;
                if(nx == -1 || ny == -1 || nx == m || ny == n || image[nx][ny] != orig)
                    continue;
                image[nx][ny] = color;
                queue.offer(new int[]{nx, ny});
            }
        }
        
        return image;
    }
}