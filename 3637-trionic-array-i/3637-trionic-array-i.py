# we just count how many slopes are present in array. it should be 3
class Solution:
    def isTrionic(self, nums: List[int]) -> bool:
        n, count = len(nums), 1
        if nums[0] >= nums[1]: return False

        for i in range(2, n):
            if nums[i - 1] == nums[i]: return False
            # if slope changes then increment count
            if (nums[i - 2] - nums[i - 1]) * (nums[i - 1] - nums[i]) < 0: count += 1
        
        return count == 3