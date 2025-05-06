class Solution:
    def buildArray(self, nums: List[int]) -> List[int]:
        n = len(nums)
        return [nums[nums[_]] for _ in range(n)]