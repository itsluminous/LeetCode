func findMaxK(nums []int) int {
    sort.Ints(nums)
    left, right := 0, len(nums)-1
    for left < right{
        if nums[left] > 0 {break}
        if -nums[left] == nums[right] {return nums[right]}

        if -nums[left] > nums[right]{
            left++
        } else {
            right--
        }
    }
    return -1
}