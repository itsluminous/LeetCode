class Solution:
    def maxMatrixSum(self, matrix: List[List[int]]) -> int:
        matrixSum, negatives, smallest = 0, 0, 1_00_001

        # count total negatives in matrix
        # and maintain matrixSum & smallest num
        for row in matrix:
            for val in row:
                if val < 0: negatives += 1
                matrixSum += abs(val)
                smallest = min(smallest, abs(val))

        # if negatives are even, then we can make all of them positive after certain swaps
        # in case of odd, one negative will always be left, so we will make smallest as negative
        if (negatives & 1) == 0: return matrixSum
        return matrixSum - 2 * smallest    # 2*smallest because we had added this smallest earlier