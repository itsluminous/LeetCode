func minDifference(nums []int) int {
    if len(nums) <= 3 {
        return 0
    }
        
    n := len(nums) - 1
    sort.Ints(nums)

    // manually check all 4 combinations
    minDiff := min(nums[n]-nums[3], nums[n-1]-nums[2], nums[n-2]-nums[1], nums[n-3]-nums[0])
    return minDiff
}