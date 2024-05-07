func rob(nums []int) int {
    notRob, rob := 0, nums[0]
    for i:=1; i<len(nums); i++ {
        notRobCurr := max(notRob, rob)
        rob = notRob + nums[i]
        notRob = notRobCurr
    }

    return max(rob, notRob)
}