class Solution:
    def hasAlternatingBits(self, n: int) -> bool:
        prev = 100 # anything random
        while n != 0:
            curr = (n & 1)
            if prev == curr: return False
            prev = curr
            n >>= 1
        return True