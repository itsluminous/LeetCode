class Solution:
    def maxAdjacentDistance(self, nums: List[int]) -> int:
        n = len(nums)
        ans = abs(nums[0] - nums[n-1])
        for i in range(1, n):
            diff = abs(nums[i] - nums[i-1])
            ans = max(ans, diff)
        return ans