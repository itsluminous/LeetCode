# essentially find if number is power of two, but power should be even
# valid ans are : 2^0, 2^2, 2^4, 2^6....
# invalid are : 2^1, 2^3, 2^5, 2^7....

# O(1)
class Solution:
    def isPowerOfFour(self, n: int) -> bool:
        if n < 4: return n == 1
        if (n & (n-1)) != 0: return False    # means there are more than one bit set

        # check if even power is set
        # evenSetBin = "01010101010101010101010101010101"
        # evenSetNum = int(evenSetBin, 2)
        # return (n & evenSetNum) != 0

        # alternate
        # Bitmask: 0x55555555 = 01010101010101010101010101010101
        return (n & 0x55555555) != 0

# Accepted - O(31)
class SolutionElaborate:
    def isPowerOfFour(self, n: int) -> bool:
        if n < 4: return n == 1
        oddPos = False
        oneBit = 0
        while n > 0:
            if (n & 1) == 1:
                oneBit += 1
                if oddPos or oneBit > 1: return False
            oddPos = not oddPos
            n >>= 1
        return True