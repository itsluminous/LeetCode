func maximumSubarraySum(nums []int, k int) int64 {
    pos := make([]int, 100001)    // pos of when a number was last seen
    for i := range pos {
        pos[i] = -1
    }

    dupIdx := -1
    var maxSum, currSum int64 = 0, 0

    for i:=0; i<len(nums); i++ {
        currSum += int64(nums[i])
        if i >= k {
            currSum -= int64(nums[i-k])
        }

        // find out index of duplicate num in curr subarray
        dupIdx = max(dupIdx, pos[nums[i]])
        pos[nums[i]] = i

        if i - dupIdx >= k {
            maxSum = max(maxSum, currSum)
        }
    }

    return maxSum
}