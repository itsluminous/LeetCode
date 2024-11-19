class Solution:
    def maximumSubarraySum(self, nums: List[int], k: int) -> int:
        pos = [-1] * 1_00_001    # pos of when a number was last seen

        dupIdx = -1
        maxSum = currSum = 0

        for i in range(len(nums)):
            currSum += nums[i]
            if i >= k: currSum -= nums[i-k]

            # find out index of duplicate num in curr subarray
            dupIdx = max(dupIdx, pos[nums[i]])
            pos[nums[i]] = i

            if i - dupIdx >= k: maxSum = max(maxSum, currSum)

        return maxSum