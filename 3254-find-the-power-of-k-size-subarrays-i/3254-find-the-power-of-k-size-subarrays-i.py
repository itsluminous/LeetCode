class Solution:
    def resultsArray(self, nums: List[int], k: int) -> List[int]:
        n = len(nums)
        ans = [-1] * (n-k+1)

        l, r, wrongIdx = 0, 1, -1
        while(r < k):
            if nums[r] != 1 + nums[r-1]:
                wrongIdx = r-1
            r += 1
        if wrongIdx < l: ans[l] = nums[r-1]

        for l in range(1, n-k+1):
            if nums[r] != 1 + nums[r-1]:
                wrongIdx = r-1
            r += 1
            if wrongIdx < l: ans[l] = nums[r-1]
            
        return ans