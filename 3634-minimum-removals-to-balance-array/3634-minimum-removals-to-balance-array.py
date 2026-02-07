class Solution:
    def minRemoval(self, nums: List[int], k: int) -> int:
        nums.sort()
        n = len(nums)
        r, ans = 0, n-1

        for l in range(n):
            while r < n and nums[r] <= nums[l] * k: r += 1
            ans = min(ans, n - (r-l))

        return ans