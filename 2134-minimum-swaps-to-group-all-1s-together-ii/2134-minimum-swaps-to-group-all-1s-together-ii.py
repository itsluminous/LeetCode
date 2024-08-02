class Solution:
    def minSwaps(self, nums: List[int]) -> int:
        n, n2 = len(nums), 2 * len(nums)
        totalOnes = Counter(nums)[1]

        if totalOnes <= 1: return 0

        maxOnesInWindow = currOnes = 0
        for i in range(n2):
            currOnes += nums[i % n]
            # if left of window was one, then decrement
            if i >= totalOnes and nums[(i - totalOnes) % n] == 1:
                currOnes -= 1
            maxOnesInWindow = max(maxOnesInWindow, currOnes)

        return totalOnes - maxOnesInWindow