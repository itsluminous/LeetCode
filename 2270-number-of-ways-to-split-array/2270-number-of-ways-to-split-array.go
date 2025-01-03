func waysToSplitArray(nums []int) int {
    left, right := int64(nums[0]), sum(nums[1:])
    count := 0

    if left >= right{
        count++
    }

    for i:=1; i < len(nums) - 1; i++ {
        left += int64(nums[i])
        right -= int64(nums[i])
        if left >= right {
            count++
        }
    }

    return count
}

func sum(nums []int) int64 {
    var total int64 = 0
    for _, num := range nums {
        total += int64(num)
    }
    return total
}