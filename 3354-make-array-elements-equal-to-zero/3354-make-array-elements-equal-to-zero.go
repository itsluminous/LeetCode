func countValidSelections(nums []int) int {
    n := len(nums)
    leftSum := make([]int, n)
    rightSum := make([]int, n)

    for i := 1; i < n; i++ {
        leftSum[i] = leftSum[i-1] + nums[i-1]
        rightSum[n-i-1] = rightSum[n-i] + nums[n-i]
    }
        
    ans := 0
    for i := 0; i < n; i++ {
        if nums[i] != 0 {
            continue
        }
        diff := int(math.Abs(float64(leftSum[i] - rightSum[i])))
        if diff == 0 { // we can go in left & right dir both
            ans += 2
        }
        if diff == 1 { // we can go only in one direction
            ans += 1
        }
    }

    return ans
}