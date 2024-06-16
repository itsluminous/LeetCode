# if we have a number `num` present, then we definitely have all numbers till `num` possible
# so we just need to keep track of what is max number we can reach
class Solution:
    def minPatches(self, nums: List[int], n: int) -> int:
        maxNum, patched = 1, 0
        nl, idx = len(nums), 0
        while maxNum <= n:
            if idx  < nl and nums[idx] <= maxNum:
                maxNum += nums[idx]
                idx += 1
            else:
                patched += 1
                maxNum *= 2

        return patched