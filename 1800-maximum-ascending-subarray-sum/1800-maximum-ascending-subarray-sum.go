func maxAscendingSum(nums []int) int {
    maxSum, currSum := nums[0], nums[0]

    for i:=1; i<len(nums); i++ {
        if nums[i] <= nums[i-1] {
            maxSum = max(maxSum, currSum)
            currSum = nums[i]
        } else {
            currSum += nums[i]
        }
    }
    maxSum = max(maxSum, currSum)
    return maxSum
}

func max(num1, num2 int) int {
    if num1 > num2 {
        return num1
    }
    return num2
}