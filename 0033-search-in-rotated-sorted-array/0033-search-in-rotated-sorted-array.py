class Solution:
    def search(self, nums: List[int], target: int) -> int:
        n = len(nums)
        left, right = 0, n-1
        
        while left < right:
            mid = left + (right - left) // 2
            if nums[mid] > nums[right]:
                left = mid + 1
            else:
                right = mid
        
        # rotated "left" times
        return self.searchRotated(nums, target, left)
    
    def searchRotated(self, nums: List[int], target: int, pivot: int) -> int:
        n = len(nums)
        left, right = 0, n-1

        while left <= right:    # <= so that we can handle array with len = 1
            mid = left + (right - left) // 2
            realMid = (mid + pivot) % n
            if nums[realMid] == target:
                return realMid
            if nums[realMid] < target:
                left = mid + 1
            else:
                right = mid - 1 # r=mid-1 and not r=mid because while loop condition is l<=r, hence avoiding infinite loop
        
        return -1   # not found
