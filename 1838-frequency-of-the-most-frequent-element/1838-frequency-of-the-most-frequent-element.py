class Solution:
    def maxFrequency(self, nums: List[int], k: int) -> int:
        nums.sort()
        n, l, r, sum = len(nums), 0, 0, 0
        
        for r in range(n):
            sum += nums[r]
            operationsToMakeAllSame = (r-l+1)*nums[r] - sum
            if operationsToMakeAllSame > k:
                sum -= nums[l]
                l += 1

        return n-l