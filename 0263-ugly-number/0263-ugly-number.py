class Solution:
    def isUgly(self, n: int) -> bool:
        if n == 0: return False
        for div in range(5, 1, -1):
            while n % div == 0:
                n //= div
        return n == 1