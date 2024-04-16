# O(n) - using extra space
class Solution:
    def maxOperations(self, nums: List[int], k: int) -> int:
        dict = defaultdict(int)
        ops = 0
        for num in nums:
            if num in dict:
                ops +=1
                dict[num] -=1
                if dict[num] == 0: del dict[num]
            else: dict[k - num] +=1
        return ops

# Accepted, using no space - O(NlogN)
class SolutionSort:
    def maxOperations(self, nums: List[int], k: int) -> int:
        nums.sort()
        l, r, ops = 0, len(nums)-1, 0
        
        while l < r:
            sum = nums[l] + nums[r]
            if sum == k:
                ops, l, r = ops+1, l+1, r-1
            elif sum < k: l += 1
            else: r -= 1
        return ops