class Solution:
    def isArraySpecial(self, nums: List[int]) -> bool:
        for i in range(len(nums)-1):
            if (nums[i] & 1) == (nums[i+1] & 1):
                return False
        return True