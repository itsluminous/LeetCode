public class Solution {
    public int equalPairs(int[][] grid) {
        var rows = new HashMap<String, Integer>();
        int m = grid.length, n = grid[0].length, count = 0;
        
        for(var i=0; i<m; i++){
            var sb = new StringBuilder();
            for(var j=0; j<n; j++)
                sb.append(grid[i][j] + " : ");

            var key = sb.toString();
            rows.put(key, rows.getOrDefault(key, 0) + 1);
        }

        for(var i=0; i<m; i++){
            var sb = new StringBuilder();
            for(var j=0; j<n; j++)
                sb.append(grid[j][i] + " : ");

            var key = sb.toString();
            count += rows.getOrDefault(key, 0);
        }

        return count;
    }
}