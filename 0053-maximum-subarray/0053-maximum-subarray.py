class Solution:
    def maxSubArray(self, nums: List[int]) -> int:
        maxSum, currSum = -inf, 0
        for num in nums:
            currSum = max(currSum + num, num)
            maxSum = max(maxSum, currSum)
        
        return maxSum
