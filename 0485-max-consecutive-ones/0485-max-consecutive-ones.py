class Solution:
    def findMaxConsecutiveOnes(self, nums: List[int]) -> int:
        ans = curr = 0
        for num in nums:
            if num == 1:
                curr += 1
            elif curr > 0:
                ans = max(ans, curr)
                curr = 0

        return max(ans, curr)