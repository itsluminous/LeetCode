class Solution:
    def minOperations(self, nums: List[int]) -> int:
        flips = 0

        for i in range(0, len(nums) - 2):
            if nums[i] == 1: continue
            
            flips += 1
            nums[i+1] ^= 1     # flip next number
            nums[i+2] ^= 1     # flip next to next number

        if nums[-1] == 0 or nums[-2] == 0: return -1   # failure, if there are pending flips 
        return flips