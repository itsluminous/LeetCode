class Solution:
    def maxSum(self, nums: List[int]) -> int:
        nums.sort()
        if nums[-1] < 0: return nums[-1] # if only negative numbers

        total = prev = 0
        for num in nums:
            if num < 0 or num == prev: continue
            total += num
            prev = num

        return total