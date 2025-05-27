class Solution:
    def differenceOfSums(self, n: int, m: int) -> int:
        c = n // m                              # count of numbers divisble by m
        allSum = n * (n+1) / 2                  # AP sum of first n numbers
        mSum = (c * (2 * m + (c - 1) * m)) / 2  # AP sum formula = n/2 * (2*a + (n - 1)*d)
        return int(allSum - 2 * mSum)           # 2* because we need to subtract extra mSum counted in allSum

# Accepted - O(n)
class SolutionN:
    def differenceOfSums(self, n: int, m: int) -> int:
        ans = 0
        for i in range(1, n+1):
            if i % m == 0: ans -= i
            else: ans += i
        return ans