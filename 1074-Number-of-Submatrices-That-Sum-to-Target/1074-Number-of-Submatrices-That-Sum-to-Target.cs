public class Solution {
    public int NumSubmatrixSumTarget(int[][] matrix, int target) {
        var count = 0;
        int rows = matrix.Length, cols = matrix[0].Length +1; // +1 to add one col at start with 0 value
        var prefixSum = new int[rows, cols];

        // find prefix sum for all rows in matrix
        for(var i=0; i<rows; i++)
            for(var j=1; j<cols; j++)
                prefixSum[i,j] = prefixSum[i,j-1] + matrix[i][j-1];

        for(var start=0; start<cols; start++){
            for(var end=start+1; end<cols; end++){
                var sumOfSubMatrix = 0;
                // now prefix sum logic follows
                // Refer for logic : https://leetcode.com/problems/subarray-sum-equals-k/
                var dict = new Dictionary<int, int>();
                dict[0] = 1;    // one way to get 0 sum
                for(var r=0; r<rows; r++){
                    sumOfSubMatrix += prefixSum[r,end] - prefixSum[r,start];
                    if(dict.ContainsKey(sumOfSubMatrix-target))
                        count += dict[sumOfSubMatrix-target];
                    dict[sumOfSubMatrix] = dict.ContainsKey(sumOfSubMatrix) ? dict[sumOfSubMatrix]+1 : 1;
                }
            }
        }

        return count;
    }
}