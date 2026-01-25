class Solution:
    def minimumDifference(self, nums: List[int], k: int) -> int:
        nums.sort()
        n = len(nums)
        
        ans = nums[n-1] - nums[0]
        if k == n: return ans
        for i in range(k, n+1):
            ans = min(ans, nums[i-1] - nums[i-k])
        
        return ans