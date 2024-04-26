# The guess API is already defined for you.
# @param num, your guess
# @return -1 if num is higher than the picked number
#          1 if num is lower than the picked number
#          otherwise return 0
# def guess(num: int) -> int:

class Solution:
    def guessNumber(self, right: int, left :int = 1) -> int:
        mid = left + (right - left)//2
        match = guess(mid)
        if(match == -1): return self.guessNumber(mid, left)
        if(match == 1): return self.guessNumber(right, mid+1)
        return mid