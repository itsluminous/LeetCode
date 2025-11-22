class Solution:
    def minimumOperations(self, nums: List[int]) -> int:
        ops = 0
        for num in nums:
            if num % 3 != 0: ops += 1
        return ops