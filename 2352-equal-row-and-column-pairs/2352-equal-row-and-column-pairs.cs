public class Solution {
    public int EqualPairs(int[][] grid) {
        var rows = new Dictionary<string, int>();
        int m = grid.Length, n = grid[0].Length, count = 0;
        
        for(var i=0; i<m; i++){
            var sb = new StringBuilder();
            for(var j=0; j<n; j++)
                sb.Append($"{grid[i][j]} : ");

            var key = sb.ToString();
            if(rows.ContainsKey(key)) rows[key]++;
            else rows[key] = 1;
        }

        for(var i=0; i<m; i++){
            var sb = new StringBuilder();
            for(var j=0; j<n; j++)
                sb.Append($"{grid[j][i]} : ");

            var key = sb.ToString();
            if(rows.ContainsKey(key)) count += rows[key];
        }

        return count;
    }
}