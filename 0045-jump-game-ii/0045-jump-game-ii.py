class Solution:
    def jump(self, nums: List[int]) -> int:
        jumps = maxEnd = currEnd = 0

        for i in range(len(nums) - 1):
            maxEnd = max(maxEnd, i + nums[i])
            if i == currEnd:
                jumps += 1
                currEnd = maxEnd

                if currEnd >= len(nums): return jumps   # early exit
        
        return jumps
            