class Solution:
    def minimumMountainRemovals(self, nums: List[int]) -> int:
        n = len(nums)
        # single number is also LIS, hence default value of 1
        left, right = [1]*n, [1]*n

        # LIS on left
        for i in range(1, n):
            for j in range(i):
                if nums[j] < nums[i] and left[i] < left[j]+1:
                    left[i] = left[j]+1
        
        # LDS on right
        for i in range(n-2, -1, -1):
            for j in range(n-1, i, -1):
                if nums[j] < nums[i] and right[i] < right[j]+1:
                    right[i] = right[j]+1
        
        # identify biggest mountain
        maxLen = 0
        for i in range(1, n-1):
            if left[i] > 1 and right[i] > 1:
                maxLen = max(maxLen, left[i] + right[i] - 1)  # -1 because curr no would be counted twice

        return n - maxLen