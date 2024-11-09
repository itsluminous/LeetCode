# Let x be 38 (100110), and n be 37.
# smallest no. in array will always be x (because all bits in x need to be 1)
# so we need remaining 37 - 1 = 36 (100100) additional elements.
# we need to fit these 100100 of 36 in the 0's of 38 (000100110)
# 36    1 0 0   1 0     0
# 38    0 0 0 1 0 0 1 1 0
# ans   1 0 0 1 1 0 1 1 0
class Solution:
    def minEnd(self, n: int, x: int) -> int:
        num, remaining, pos = x, n-1, 1
        while remaining > 0:
            if (pos & x) == 0:                 # the bit at this pos is 0 in x, so can be used
                num |= pos * (remaining & 1)   # set num's bit at pos position if last bit of remaining is 1
                remaining >>= 1                # right shift remaining, so that we try next pos now
            pos <<= 1

        return num

# O(n) - TLE in python, accepted in java & c#
# smallest no. in array will always be x
# so we start from x and keep incrementing till count is n
# in every increment, ensure that at least same bits as x are set
class SolutionLinear:
    def minEnd(self, n: int, x: int) -> int:
        num = x
        for _ in range(1, n):
            num += 1      # increment num
            num |= x    # ensure that at least the bits in x are set
        return num