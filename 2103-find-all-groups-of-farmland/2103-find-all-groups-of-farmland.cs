public class Solution {
    public int[][] FindFarmland(int[][] land) {
        int m = land.Length, n = land[0].Length;
        var ans = new List<int[]>();
        
        for(var i=0; i<m; i++){
            for(var j=0; j<n; j++){
                if(land[i][j] == 0) continue;
                var (minX, minY) = (i,j);
                var (maxX, maxY) = DFS(land, i, j);
                ans.Add(new[]{minX, minY, maxX, maxY});
            }
        }

        return ans.ToArray();
    }

    private (int, int) DFS(int[][] land, int x, int y) {
        land[x][y] = 0;
        
        int m = land.Length, n = land[0].Length;
        var (maxX, maxY) = (x, y);
        if(x < m-1 && land[x+1][y] != 0){
            var (tx, ty) = DFS(land, x+1, y);
            (maxX, maxY) = (Math.Max(maxX, tx), Math.Max(maxY, ty));
        }
        if(y < n-1 && land[x][y+1] != 0){
            var (tx, ty) = DFS(land, x, y+1);
            (maxX, maxY) = (Math.Max(maxX, tx), Math.Max(maxY, ty));
        }

        return (maxX, maxY);
    }
}