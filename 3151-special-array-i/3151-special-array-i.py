class Solution:
    def isArraySpecial(self, nums: List[int]) -> bool:
        n = len(nums)
        for i in range(n-1):
            if (nums[i] & 1) == 1 and (nums[i+1] & 1) == 1: return False
            if (nums[i] & 1) == 0 and (nums[i+1] & 1) == 0: return False
        return True