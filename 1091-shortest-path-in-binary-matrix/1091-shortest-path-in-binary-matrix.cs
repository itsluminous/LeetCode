public class Solution {
    public int ShortestPathBinaryMatrix(int[][] grid) {
        int n = grid.Length, path = 0;
        if(grid[0][0] == 1 || grid[n-1][n-1] == 1) return -1;   // invalid case
        
        // BFS
        var q = new Queue<(int x, int y)>();
        q.Enqueue((0,0));
        while(q.Count > 0){
            var len = q.Count;
            path++;
            for(var i=0; i<len; i++){
                var point = q.Dequeue();
                if(point.x == n-1 && point.y == n-1)
                    return path;
                // check all neighbours
                for(var x=-1; x<=1; x++){
                    for(var y=-1; y<=1; y++){
                        int newx = point.x + x, newy = point.y + y;
                        if(newx < 0 || newx == n || newy < 0 || newy == n || grid[newx][newy] == 1)
                            continue;
                        q.Enqueue((newx, newy));
                        grid[newx][newy] = 1;
                    }
                }
            }
        }
        
        return -1;  // if we reached here, it means there is no path to reach last point
    }
}