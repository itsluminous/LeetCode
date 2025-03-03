class Solution:
    def pivotArray(self, nums: List[int], pivot: int) -> List[int]:
        n = len(nums)
        ans = [pivot] * n
        smallIdx, bigIdx = 0, n-1

        # iterate from both directions (left & right), and fill ans 
        i, j = 0, n-1
        while i < n:
            if nums[i] < pivot:
                ans[smallIdx] = nums[i]
                smallIdx += 1
            if nums[j] > pivot:
                ans[bigIdx] = nums[j]
                bigIdx -= 1
            
            i += 1
            j -= 1
        
        return ans

# Accepted - modifying original nums array
class SolutionArr:
    def pivotArray(self, nums: List[int], pivot: int) -> List[int]:
        n = len(nums)
        bigger = [0] * n    # array to store numbers bigger than pivot
        eq = 0              # count of numbers equal to pivot
        smallIdx = bigIdx = 0

        # move all small to left side in nums
        # copy all big ones to "bigger" array
        # and just keep a count of numbers equal to pivot
        for i, num in enumerate(nums):
            if num < pivot:
                nums[smallIdx] = num
                smallIdx += 1
            elif num > pivot:
                bigger[bigIdx] = num
                bigIdx += 1
            else:
                eq += 1

        # fill up all equal numbers
        for _ in range(eq):
            nums[smallIdx] = pivot
            smallIdx += 1
        
        # fill up all bigger numbers
        for i in range(bigIdx):
            nums[smallIdx] = bigger[i]
            smallIdx += 1
        
        return nums