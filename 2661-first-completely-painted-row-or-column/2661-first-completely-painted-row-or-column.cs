public class Solution {
    public int FirstCompleteIndex(int[] arr, int[][] mat) {
        int m = mat.Length, n = mat[0].Length;

        // pre-process the positions of the values in the matrix.
        var pos = new Dictionary<int, int[]>();
        for(var i=0; i<m; i++)
            for(var j=0; j<n; j++)
                pos[mat[i][j]] = [i, j];
        
        // for each value in row, check if it fills row or col
        int[] rows = new int[m], cols = new int[n];
        for(var i=0; i<arr.Length; i++){
            var coord = pos[arr[i]];
            int r = coord[0], c = coord[1];
            rows[r]++;
            cols[c]++;

            if(rows[r] == n || cols[c] == m) return i;
        }

        return 0;
    }
}