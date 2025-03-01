class Solution:
    def applyOperations(self, nums: List[int]) -> List[int]:
        n, left, right = len(nums), 0, 0

        while right < n-1:
            if nums[right] != nums[right+1] and nums[right] != 0:
                nums[left] = nums[right]
                left += 1
                right += 1
            elif nums[right] == nums[right+1] and nums[right] == 0:
                right += 2
            elif nums[right] == nums[right+1]:
                nums[left] = 2 * nums[right]
                left += 1
                right += 2
            else:
                right += 1

        # explicit operation for last digit
        if right < n:
            nums[left] = nums[right] 
            left += 1
        
        # append 0 at end and return
        while left < n: 
            nums[left] = 0
            left += 1

        return nums