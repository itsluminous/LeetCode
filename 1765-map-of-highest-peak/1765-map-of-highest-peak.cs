public class Solution {
    public int[][] HighestPeak(int[][] isWater) {
        int m = isWater.Length, n = isWater[0].Length;
        var queue = new Queue<(int x, int y)>();
        for(var i=0; i<m; i++)
            for(var j=0; j<n; j++)
                if(isWater[i][j] == 1){
                    queue.Enqueue((i, j));
                    isWater[i][j] = -1;     // set all water to -1 to differentiate it
                }
        
        var waters = queue.ToList();
        var dirs = new []{(0, -1), (0, 1), (-1, 0), (1, 0)};
        
        for(var height = 1; queue.Count > 0; height++){
            for(var i=queue.Count; i>0; i--){
                var (x, y) = queue.Dequeue();
                foreach(var (dx, dy) in dirs){
                    int xx = x + dx, yy = y + dy;
                    if(xx == -1 || yy == -1 || xx == m || yy == n || isWater[xx][yy] != 0) continue;

                    queue.Enqueue((xx, yy));
                    isWater[xx][yy] = height;
                }
            }
        }

        // change all water from -1 to 0
        foreach(var (x, y) in waters)
            isWater[x][y] = 0;
        
        return isWater;
        
    }
}