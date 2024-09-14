class Solution:
    def longestSubarray(self, nums: List[int]) -> int:
        prev = currCount = maxCount = maxVal = 0
        for i, num in enumerate(nums):
            if num > maxVal:
                currCount = maxCount = 1
                maxVal = num
            if num == maxVal:
                if prev != maxVal:
                    currCount = 1
                else:
                    currCount += 1
                    maxCount = max(maxCount, currCount)
            prev = num
        return maxCount