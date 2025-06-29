class Solution:
    def numSubseq(self, nums: List[int], target: int) -> int:
        n = len(nums)
        MOD = 1_000_000_007
        nums.sort()
        
        # sliding window
        l, r, ans = 0, n-1, 0
        while l <= r:
            if nums[l] + nums[r] > target:
                r -= 1
            else:
                # x indexes in between can be picked in 2^x ways, including 0 pick (combination formula)
                numsInBetween = r - l
                ans += pow(2, numsInBetween, MOD)
                l += 1

        return ans % MOD