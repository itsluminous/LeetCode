# @votrubac : since nums[i] + nums[j] == nums[j] + nums[i], the i < j condition degrades to i != j
# count all pairs whose sum <= upper bound (this will include pairs lower than lower bound)
# count all pairs whose sum < lower bound
# subtract lower bound pairs from upper bound pairs, to get pairs b/w lower & upper
class Solution:
    def countFairPairs(self, nums: List[int], lower: int, upper: int) -> int:
        nums.sort()
        return self.countLessPairs(nums, upper) - self.countLessPairs(nums, lower-1)

    def countLessPairs(self, nums, maxVal):
        count = 0
        l,r = 0, len(nums)-1
        while l < r:
            while l < r and nums[l] + nums[r] > maxVal: r -= 1
            count += r - l
            l += 1
        return count

# @votrubac : since nums[i] + nums[j] == nums[j] + nums[i], the i < j condition degrades to i != j
# for each index in array:
#   get index of first element with sum < lower bound
#   get index of first element with sum <= upper bound
#   count = upper bound idx - lower bound idx
class SolutionBS:
    def countFairPairs(self, nums: List[int], lower: int, upper: int) -> int:
        nums.sort()
        n = len(nums)
        count = 0
        for i,num in enumerate(nums):
            # index of first element with sum < lower bound
            low = self.getLowerBound(nums, i+1, n-1, lower - num)
            # index of first element with sum <= upper bound
            high = self.getLowerBound(nums, i+1, n-1, upper - num + 1)

            count += high - low
        return count

    def getLowerBound(self, nums, low, high, num):
        while low <= high:
            mid = low + (high - low) // 2
            if nums[mid] >= num: high = mid-1
            else: low = mid+1
        return low