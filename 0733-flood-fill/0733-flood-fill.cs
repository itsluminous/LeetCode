public class Solution {
    public int[][] FloodFill(int[][] image, int sr, int sc, int color) {
        if(image[sr][sc] == color) return image;

        int m = image.Length, n = image[0].Length;
        var orig = image[sr][sc];
        image[sr][sc] = color;

        var queue = new Queue<(int, int)>();
        queue.Enqueue((sr, sc));

        (int, int)[] dirs = [(0, 1), (0, -1), (1, 0), (-1, 0)];
        while(queue.Count > 0){
            var (x, y) = queue.Dequeue();
            foreach(var (dx, dy) in dirs){
                int nx = x + dx, ny = y + dy;
                if(nx == -1 || ny == -1 || nx == m || ny == n || image[nx][ny] != orig)
                    continue;
                image[nx][ny] = color;
                queue.Enqueue((nx, ny));
            }
        }
        
        return image;
    }
}