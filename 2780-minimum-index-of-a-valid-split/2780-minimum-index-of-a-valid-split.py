class Solution:
    def minimumIndex(self, nums: List[int]) -> int:
        n = len(nums)
        if n < 2: return -1

        # find the dominant number
        domNum, domCount = nums[0], 0
        for num in nums:
            if num == domNum: domCount += 1
            elif domCount > 1: domCount -= 1
            else: domNum = num

        # find dominant number's count
        domCount = 0
        for num in nums:
            if num == domNum: domCount += 1

        # find the first split position
        leftDomCount = 0
        for i, num in enumerate(nums):
            if num == domNum:
                leftDomCount += 1
            
            leftDom = leftDomCount > (i + 1) // 2
            rightDom = (domCount - leftDomCount) > (n - i - 1) // 2
            if leftDom and rightDom: return i

        return -1