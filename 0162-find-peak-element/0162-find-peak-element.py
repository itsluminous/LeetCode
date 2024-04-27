class Solution:
    def findPeakElement(self, nums: List[int]) -> int:
        left, right = 0, len(nums)-1
        while left < right:
            mid = left + (right-left)//2
            if mid != len(nums) and nums[mid] < nums[mid+1]: left = mid+1  # if it is on left slope
            else: right = mid    # it is on right slope
        return left