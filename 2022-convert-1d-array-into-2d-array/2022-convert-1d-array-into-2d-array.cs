public class Solution {
    public int[][] Construct2DArray(int[] original, int m, int n) {
        int len = original.Length, r = -1, c = 0;
        if(len != m*n) return new int[0][];

        var matrix = new int[m][];
        for(var i=0; i<m; i++) matrix[i] = new int[n];

        for(var i=0; i<len; i++){
            if(i % n == 0){
                r++;
                c = 0;
            }
            matrix[r][c++] = original[i];
        }

        return matrix;
    }
}