public class Solution {
    public IList<int> LuckyNumbers (int[][] matrix) {
        int m = matrix.Length, n = matrix[0].Length;
        var rowMin = new int[m];
        var ans = new List<int>();

        for(var i=0; i<m; i++){
            var mn = matrix[i][0];
            for(var j=1; j<n; j++)
                mn = Math.Min(mn, matrix[i][j]);
            rowMin[i] = mn;
        }

        for(var j=0; j<n; j++){
            var mx = matrix[0][j];
            for(var i=1; i<m; i++)
                mx = Math.Max(mx, matrix[i][j]);
            
            for(var i=0; i<m; i++)
                if(rowMin[i] == mx){
                    ans.Add(mx);
                    break;
                }
        }

        return ans;
    }
}