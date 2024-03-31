class Solution:
    def countAlternatingSubarrays(self, nums: List[int]) -> int:
        ans = 1
        n = len(nums)
        l = 0

        for r in range(1,n):
            if nums[r] == nums[r-1]:
                l = r
            ans += (r-l+1)
        
        return ans