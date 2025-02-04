class Solution:
    def maxAscendingSum(self, nums: List[int]) -> int:
        maxSum = currSum = nums[0]
        
        for i in range(1, len(nums)):
            if nums[i] <= nums[i-1]:
                maxSum = max(maxSum, currSum)
                currSum = nums[i]
            else:
                currSum += nums[i]

        maxSum = max(maxSum, currSum)
        return maxSum