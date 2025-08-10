# a number is power of 2 if only a single bit is set
class Solution:
    def isPowerOfTwo(self, n: int) -> bool:
        if n < 2: return n == 1
        # count number of bits set
        oneBit = 0
        while n > 0:
            if (n & 1) == 1: oneBit += 1
            n >>= 1
        return oneBit < 2

# using shortcut for same logic
class SolutionShort:
    def isPowerOfTwo(self, n: int) -> bool:
        if n < 2: return n == 1
        return (n & n-1) == 0