class Solution:
    def pivotIndex(self, nums: List[int]) -> int:
        n = len(nums)
        pref = [0]*n

        for i in range(n-2, -1, -1):
            pref[i] = nums[i+1] + pref[i+1]

        left = 0
        for i in range(n):
            if left == pref[i]: return i
            left += nums[i]
        
        return -1