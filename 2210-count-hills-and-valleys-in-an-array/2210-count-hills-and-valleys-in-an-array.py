class Solution:
    def countHillValley(self, nums: List[int]) -> int:
        n, ans, start = len(nums), 0, 1

        # skip all initial equal numbers
        while start < n and nums[start] == nums[start-1]: start += 1
        if start == n: return 0

        # find all maxima and minima
        dir = 1 if nums[start] > nums[start-1] else -1    # 1 = up, -1 = down
        for i in range(start+1, n):
            if nums[i] == nums[i-1]: continue  # equal neighbour
            
            newDir = 1 if nums[i] > nums[i-1] else -1
            if newDir != dir: ans += 1    # found maxima or minima
            dir = newDir

        return ans