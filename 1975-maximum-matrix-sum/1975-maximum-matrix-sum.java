class Solution {
    public long maxMatrixSum(int[][] matrix) {
        long matrixSum = 0;
        int negatives = 0, smallest = 1_00_001;

        // count total negatives in matrix
        // and maintain matrixSum & smallest num
        for(var row : matrix){
            for(var val : row){
                if(val < 0) negatives++;
                matrixSum += Math.abs(val);
                smallest = Math.min(smallest, Math.abs(val));
            }
        }

        // if negatives are even, then we can make all of them positive after certain swaps
        // in case of odd, one negative will always be left, so we will make smallest as negative
        if((negatives & 1) == 0) return matrixSum;
        return matrixSum - 2 * smallest;    // 2*smallest because we had added this smallest earlier
    }
}