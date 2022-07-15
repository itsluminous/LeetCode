public class Solution {
    public int MaxAreaOfIsland(int[][] grid) {
        int max = 0;
        
        for(var i=0; i<grid.Length; i++)
            for(var j=0; j<grid[0].Length; j++)
                if(grid[i][j] != 0)
                    max = Math.Max(max, LengthOfIsland(grid, i, j));
        
        return max;
    }
    
    private int LengthOfIsland(int[][] grid, int i, int j){
        int m = grid.Length, n = grid[0].Length;
        var q = new Queue<(int, int)>();
        q.Enqueue((i,j));
        var size = 0;
        do{
            var count = q.Count;
            size += count;
            for(var k=0; k<count; k++){
                (int x, int y) = q.Dequeue();
                grid[x][y] = 0;
                if(x-1 >= 0 && grid[x-1][y] == 1){
                    q.Enqueue((x-1, y));
                    grid[x-1][y] = 0;
                }   
                if(x+1 < m && grid[x+1][y] == 1){
                    q.Enqueue((x+1, y));
                    grid[x+1][y] = 0;
                }
                if(y-1 >= 0 && grid[x][y-1] == 1){
                    q.Enqueue((x, y-1));
                    grid[x][y-1] = 0;
                }
                if(y+1 < n && grid[x][y+1] == 1){
                    q.Enqueue((x, y+1));
                    grid[x][y+1] = 0;
                }
            }
        } while (q.Count > 0);
        
        return size;
    }
}