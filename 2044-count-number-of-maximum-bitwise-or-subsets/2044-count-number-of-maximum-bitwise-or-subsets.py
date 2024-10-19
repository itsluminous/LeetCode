# backtracking
class Solution:
    def countMaxOrSubsets(self, nums: List[int]) -> int:
        def findCount(nums, idx, val):
            nonlocal count
            if idx == len(nums):
                count += 1 if val == target else 0
                return

            # subsets where current num is included
            findCount(nums, idx+1, val | nums[idx])
            # subsets where current num is NOT included
            findCount(nums, idx+1, val)

        target = count = 0
        for num in nums: target |= num # max or possible is OR of all nums
        findCount(nums, 0, 0)
        return count