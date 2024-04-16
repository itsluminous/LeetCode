class Solution:
    def maxArea(self, height: List[int]) -> int:
        l, r, ans = 0, len(height)-1, 0
        while l < r:
            curr = (r-l) * min(height[r], height[l])
            ans = max(ans, curr)

            if height[r] < height[l]: r -= 1
            else: l += 1
        
        return ans