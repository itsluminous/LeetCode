class Solution:
    def majorityElement(self, nums: List[int]) -> int:
        majElem, majCount = nums[0], 1
        for i in range(len(nums)):
            if nums[i] == majElem:
                majCount += 1
            elif majCount == 1:
                majElem, majCount = nums[i], 1
            else:
                majCount -= 1
        
        return majElem