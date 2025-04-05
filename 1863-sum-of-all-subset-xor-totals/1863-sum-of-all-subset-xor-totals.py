# O(N) approach
# if there are N nums, then there are 2^N subsets in total, including empty subset
# every number num is included in exactly half of these subsets
# half of 2^N is 2^N-1
# so any bit that a num sets, needs to be counted 2^N-1 times
# we need not process each num one by one, but can simply OR all the numbers together, to find out all the 1 bits
# if X is OR of all numbers, then answer is X * 2^(N-1) i.e. X << (N-1)
class Solution:
    def subsetXORSum(self, nums: List[int]) -> int:
        allOr = 0
        for num in nums: allOr |= num

        return allOr << (len(nums) - 1)

# Accepted - backtracking
class SolutionBT:
    def subsetXORSum(self, nums: List[int], idx: int = 0, currXOR: int = 0) -> int:
        if idx == len(nums): return currXOR
        return self.subsetXORSum(nums, idx+1, currXOR ^ nums[idx]) \
             + self.subsetXORSum(nums, idx+1, currXOR)