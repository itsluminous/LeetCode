class Solution:
    def binaryGap(self, n: int) -> int:
        maxDiff, currDiff = 0, -32
        while n > 0:
            if (n & 1) == 0: currDiff += 1
            else:
                maxDiff = max(maxDiff, currDiff)
                currDiff = 1
            n >>= 1
        return max(maxDiff, 0)