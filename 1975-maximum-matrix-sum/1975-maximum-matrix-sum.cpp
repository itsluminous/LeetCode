class Solution {
public:
    long long maxMatrixSum(vector<vector<int>>& matrix) {
        long long matrixSum = 0;
        int negatives = 0, smallest = 100001;

        // count total negatives in matrix
        // and maintain matrixSum & smallest num
        for(auto& row : matrix){
            for(auto val : row){
                if(val < 0) negatives++;
                matrixSum += std::abs(val);
                smallest = std::min(smallest, std::abs(val));
            }
        }

        // if negatives are even, then we can make all of them positive after certain swaps
        // in case of odd, one negative will always be left, so we will make smallest as negative
        if((negatives & 1) == 0) return matrixSum;
        return matrixSum - 2 * smallest;    // 2*smallest because we had added this smallest earlier
    }
};