class Solution:
    def numberOfChild(self, n: int, k: int) -> int:
        n -= 1    # each round will go till (n-1) only

        rounds = k // n
        k %= n

        # if even rounds, then left to right else right to left
        if (rounds & 1) == 1: return n - k
        return k