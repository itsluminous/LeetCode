class Solution:
    def nextPermutation(self, nums: List[int]) -> None:
        n = len(nums)

        # find the first pair from right side where nums[i+1] > nums[i]
        decreasingPair = n-2
        while decreasingPair >= 0 and nums[decreasingPair + 1] <= nums[decreasingPair]:
            decreasingPair -= 1
        
        if decreasingPair >= 0:
            # find out the num of right side of this which is just bigger than it
            justBigger = n-1
            while nums[justBigger] <= nums[decreasingPair]:
                justBigger -= 1
            
            # swap the two numbers
            nums[justBigger], nums[decreasingPair] = nums[decreasingPair], nums[justBigger]

        # reverse all numbers after `decreasingPair` idx (so that they now become ascending slope)
        left, right = decreasingPair+1, n-1
        while left < right:
            nums[left], nums[right] = nums[right], nums[left]
            left += 1
            right -= 1
        