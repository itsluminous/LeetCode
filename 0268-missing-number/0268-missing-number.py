class Solution:
    def missingNumber(self, nums: List[int]) -> int:
        n = len(nums)
        apSum = n*(n+1)//2
        numSum = sum(nums)
        return apSum - numSum