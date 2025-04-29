class Solution:
    def countSubarrays(self, nums: List[int], k: int) -> int:
        ans = 0
        maxNum, maxCount = max(nums), 0

        l = 0
        for r in range(len(nums)):
            if nums[r] == maxNum: maxCount += 1

            while maxCount == k:
                if nums[l] == maxNum:
                    maxCount -= 1
                l += 1
            
            ans += l
        return ans