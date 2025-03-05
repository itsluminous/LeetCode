class Solution:
    def maximumUniqueSubarray(self, nums: List[int]) -> int:
        maxSum = currSum = left = 0
        uniq = set()
        for right in range(len(nums)):
            while nums[right] in uniq:
                currSum -= nums[left]
                uniq.remove(nums[left])
                left += 1
            
            currSum += nums[right]
            uniq.add(nums[right])
            maxSum = max(maxSum, currSum)
        
        return maxSum