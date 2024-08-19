class Solution:
    def minSteps(self, n: int) -> int:
        count = 0
        while n != 1:
            for div in range(2, n+1):
                if n % div != 0: continue
                n //= div
                count += div
                break
        return count