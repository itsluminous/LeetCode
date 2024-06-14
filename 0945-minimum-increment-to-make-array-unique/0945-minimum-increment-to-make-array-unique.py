class Solution:
    def minIncrementForUnique(self, nums: List[int]) -> int:
        nums.sort()

        incr, prev = 0, -1
        for num in nums:
            expected = prev + 1

            if num < expected:
                incr += expected - num
            prev = max(expected, num)

        return incr