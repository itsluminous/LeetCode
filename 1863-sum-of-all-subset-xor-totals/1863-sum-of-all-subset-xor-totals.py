class Solution:
    def subsetXORSum(self, nums: List[int], idx: int = 0, currXOR: int = 0) -> int:
        if idx == len(nums): return currXOR
        return self.subsetXORSum(nums, idx+1, currXOR ^ nums[idx]) \
             + self.subsetXORSum(nums, idx+1, currXOR)