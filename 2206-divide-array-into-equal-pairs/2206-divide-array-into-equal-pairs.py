class Solution:
    def divideArray(self, nums: List[int]) -> bool:
        mask = 0
        for num in nums:
            mask ^= (1 << num)
        return mask == 0

# Accepted - using freq counting
class SolutionFreq:
    def divideArray(self, nums: List[int]) -> bool:
        freq = [0] * 501
        for num in nums:
            freq[num] += 1

        # odd freq cannot satisfy conditions
        for count in freq:
            if (count & 1) == 1:
                return False
        return True