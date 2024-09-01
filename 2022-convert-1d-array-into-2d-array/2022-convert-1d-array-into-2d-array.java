class Solution {
    public int[][] construct2DArray(int[] original, int m, int n) {
        var matrix = new int[m][n];
        int len = original.length, r = -1, c = 0;
        if(len != m*n) return new int[][]{};

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