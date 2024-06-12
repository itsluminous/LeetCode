func sortColors(nums []int)  {
    freq := make([]int, 3)
    for _, num := range nums {
        freq[num]++
    }

    idx := 0
    for num := 0; num < 3; num++ {
        for i := 0; i < freq[num]; i++ {
            nums[idx] = num
            idx++
        }
    }
}