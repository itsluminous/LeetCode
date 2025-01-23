public class Solution {
    public int CountServers(int[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        
        // count servers in each row & col
        int[] rows = new int[m], cols = new int[n];
        for(var i=0; i<m; i++){
            for(var j=0; j<n; j++){
                rows[i] += grid[i][j];
                cols[j] += grid[i][j];
            }
        }

        // find out servers that can communicate
        var count = 0;
        for(var i=0; i<m; i++){
            for(var j=0; j<n; j++){
                if(grid[i][j] == 0 || (rows[i] == 1 && cols[j] == 1)) continue;
                count++;
            }
        }

        return count;
    }
}