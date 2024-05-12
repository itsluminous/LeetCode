func removeElement(nums []int, val int) int {
    left, right := 0, 0
    for right < len(nums){
        if nums[right] != val{
            nums[left] = nums[right]
            left++
        }
        right++
    }
    return left
}