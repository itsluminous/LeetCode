class Solution:
    def nextGreaterElements(self, nums: List[int]) -> List[int]:
        n = len(nums)
        stack = []

        # pre-populate entire array in stack to maintain circular traversing
        for num in reversed(nums):
            stack.append(num)
        
        for i in range(n-1, -1, -1):
            curr = nums[i]
            while stack and stack[-1] <= curr:
                stack.pop()
            
            if not stack:
                nums[i] = -1
            else:
                nums[i] = stack[-1]
            
            stack.append(curr)

        return nums