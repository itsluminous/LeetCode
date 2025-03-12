class Solution:
    def maximumCount(self, nums: List[int]) -> int:
        n = len(nums)
        leftZero = rightZero = n

        # find left most zero
        left, right = 0, n-1
        while left <= right:
            mid = left + (right - left) // 2
            if nums[mid] < 0:
                left = mid + 1
            else:
                leftZero = mid
                right = mid - 1
        
        # find right most zero
        left, right = 0, n-1
        while left <= right:
            mid = left + (right - left) // 2
            if nums[mid] <= 0:
                left = mid + 1
            else:
                rightZero = mid
                right = mid - 1
        
        return max(n - rightZero, leftZero)

# accepted - O(n)
class SolutionLinear:
    def maximumCount(self, nums: List[int]) -> int:
        n, idx = len(nums), 0

        # count negatives
        while idx < n and nums[idx] < 0: idx += 1
        neg = idx

        # skip zeroes, then count positives
        while idx < n and nums[idx] == 0: idx += 1
        pos = n - idx

        return max(pos, neg)