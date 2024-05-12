func removeDuplicates(nums []int) int {
    left, right := 0, 0
    // seen := [201]bool{}      // this also works
    var seen [201]bool
    
    for ; right < len(nums); {
        if(!seen[nums[right] + 100]){
            nums[left] = nums[right]
            seen[nums[right] + 100] = true
            left++
        }
        right++
    }

    return left
}