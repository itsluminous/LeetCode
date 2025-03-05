class Solution:
    def checkPossibility(self, nums: List[int]) -> bool:
        modified = False
        for i in range(1, len(nums)):
            if nums[i-1] <= nums[i]: continue           # already correct
            if modified: return False                   # only one modification allowed
            
            modified = True
            if i == 1 or nums[i] >= nums[i-2]: continue # set prev num = curr num
            nums[i] = nums[i-1]                         # set curr num = prev

        return True