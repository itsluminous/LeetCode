class Solution:
    def nextGreaterElement(self, nums1: List[int], nums2: List[int]) -> List[int]:
        greater = self.findAllGreater(nums2)
        for i, num in enumerate(nums1):
            nums1[i] = greater[num]
        
        return nums1

    def findAllGreater(self, nums):
        greater = [0] * 10001
        stack = []

        for num in reversed(nums):
            while stack and stack[-1] < num:
                stack.pop()
            
            if not stack:
                greater[num] = -1
            else:
                greater[num] = stack[-1]
            
            stack.append(num)

        return greater