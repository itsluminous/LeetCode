class Solution:
    def countSubarrays(self, nums: List[int], minK: int, maxK: int) -> int:
        min_idx = -1
        max_idx = -1
        ans = 0
        l = 0

        for r,numr in enumerate(nums):
            if numr > maxK or numr < minK:
                l = r+1
                min_idx = -1
                max_idx = -1
                continue
            
            if numr == minK:
                min_idx = r
            if numr == maxK:
                max_idx = r

            if min_idx > -1 and max_idx > -1:
                left_side_idx = min(min_idx, max_idx)
                ans += (left_side_idx - l + 1)
        
        return ans