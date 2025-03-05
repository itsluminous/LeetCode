class Solution:
    def maxChunksToSorted(self, arr: List[int]) -> int:
        # idea is that till index i, if I have found all numbers till i, I can split
        # to check if I found all nums, I can just keep track of max num found till curr index
        # if max num found matches that index, it means I found all nums
        maxNum = chunks = 0
        for i, num in enumerate(arr):
            maxNum = max(maxNum, num)
            if maxNum == i:
                chunks += 1

        return chunks

# accepted - using bitmask
class SolutionBM:
    def maxChunksToSorted(self, arr: List[int]) -> int:
        # idea is that till index i, if I have found all numbers till i, I can split
        # to check if I found all nums, I can use bitmask to track found nums
        mask = chunks = 0
        for i, num in enumerate(arr):
            mask |= (1 << num)
            expected = (1 << (i + 1)) - 1       # expected for i = 2 would be 000111, and so on
            if (mask ^ expected) == 0:
                chunks += 1

        return chunks