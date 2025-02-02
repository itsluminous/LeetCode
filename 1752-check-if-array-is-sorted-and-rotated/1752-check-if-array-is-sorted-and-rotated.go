func check(nums []int) bool {
    n := len(nums)
    rotated := false
    for i := 1; i < n; i++ {
        if nums[i] >= nums[i-1] {
            continue
        }
        if(rotated) {
            return false
        }
        rotated = true
    }

    if !rotated || nums[0] >= nums[n-1] {
        return true
    }
    return false
}