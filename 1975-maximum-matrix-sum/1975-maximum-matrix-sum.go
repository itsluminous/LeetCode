func maxMatrixSum(matrix [][]int) int64 {
    var matrixSum int64 = 0
    negatives, smallest := 0, 1_00_001

    // count total negatives in matrix
    // and maintain matrixSum & smallest num
    for _, row := range matrix {
        for _, val := range row {
            if(val < 0) {
                negatives++
            }
            matrixSum += int64(math.Abs(float64(val)))
            smallest = int(math.Min(float64(smallest), math.Abs(float64(val))))
        }
    }

    // if negatives are even, then we can make all of them positive after certain swaps
    // in case of odd, one negative will always be left, so we will make smallest as negative
    if((negatives & 1) == 0) {
        return matrixSum
    }
    return matrixSum - 2 * int64(smallest)    // 2*smallest because we had added this smallest earlier
}