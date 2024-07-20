func restoreMatrix(rowSum []int, colSum []int) [][]int {
    m, n := len(rowSum), len(colSum)
    ans := make([][]int, m)

    for i:=0; i<m; i++ {
        ans[i] = make([]int, n)
        for j:=0; j<n; j++ {
            ans[i][j] = min(rowSum[i], colSum[j])
            rowSum[i] -= ans[i][j]
            colSum[j] -= ans[i][j]
        }
    }
    
    return ans
}