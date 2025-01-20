class Solution {
    public int firstCompleteIndex(int[] arr, int[][] mat) {
        int m = mat.length, n = mat[0].length;

        // pre-process the positions of the values in the matrix.
        var pos = new HashMap<Integer, int[]>();
        for(var i=0; i<m; i++)
            for(var j=0; j<n; j++)
                pos.put(mat[i][j], new int[]{i, j});
        
        // for each value in row, check if it fills row or col
        int[] rows = new int[m], cols = new int[n];
        for(var i=0; i<arr.length; i++){
            var coord = pos.get(arr[i]);
            int r = coord[0], c = coord[1];
            rows[r]++;
            cols[c]++;

            if(rows[r] == n || cols[c] == m) return i;
        }

        return 0;
    }
}