class Solution:
    def maxSubsequence(self, nums: List[int], k: int) -> List[int]:
        n = len(nums)
        clone = nums[:]
        clone.sort()
        
        # find the starting point in sorted clone array
        mid = clone[n-k]
        midCount = 0
        i = n-k
        while i < n and clone[i] == mid:
            midCount += 1
            i += 1

        ans = [0] * k
        idx = 0    # idx in ans array
        for num in nums:
            if num > mid:
                ans[idx] = num
                idx += 1
            elif num == mid and midCount > 0:
                ans[idx] = num
                midCount
                idx += 1
                midCount -= 1

            if idx == k: break # found k digits

        return ans