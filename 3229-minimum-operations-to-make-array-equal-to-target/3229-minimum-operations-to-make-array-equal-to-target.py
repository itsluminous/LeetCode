class Solution:
    def minimumOperations(self, nums: List[int], target: List[int]) -> int:
        n = len(nums)
        incr, decr, ops = 0, 0, 0

        for i in range(n):
            diff = target[i] - nums[i]

            if diff > 0:
                if incr < diff:
                    ops += diff - incr
                incr = diff
                decr = 0
            elif diff < 0:
                if diff < decr:
                    ops += decr - diff
                decr = diff
                incr = 0
            else:
                incr = decr = 0

        return ops