public class Solution {
    public int[][] DiagonalSort(int[][] mat) {
        int m = mat.Length, n = mat[0].Length;
        
        // sort diagnonal & upper right
        int xincr = 0, yincr = 1;
        for(int x=0, y=0; x<m && y<n; x+=xincr, y+=yincr){
            var items = new List<int>();
            for(int i=x, j=y; i<m && j<n; i++, j++)
                items.Add(mat[i][j]);
            items.Sort();
            for(int i=x, j=y, idx=0; i<m && j<n; i++, j++, idx++)
                mat[i][j] = items[idx];
        }
        
        // sort bottom left
        xincr = 1; yincr = 0;
        for(int x=1, y=0; x<m && y<n; x+=xincr, y+=yincr){
            var items = new List<int>();
            for(int i=x, j=y; i<m && j<n; i++, j++)
                items.Add(mat[i][j]);
            items.Sort();
            for(int i=x, j=y, idx=0; i<m && j<n; i++, j++, idx++)
                mat[i][j] = items[idx];
        }
        
        return mat;
    }
}