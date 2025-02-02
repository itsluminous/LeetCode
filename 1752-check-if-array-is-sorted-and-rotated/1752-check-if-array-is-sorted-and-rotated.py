class Solution:
    def check(self, nums: List[int]) -> bool:
        n, rotated = len(nums), False
        for i in range(1, n):
            if nums[i] >= nums[i-1]: continue
            if rotated: return False
            rotated = True

        return not rotated or nums[0] >= nums[n-1]