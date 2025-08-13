# 3^19 is last number less than 2^31, so we don't have to check beyond that
# 3^19 = 3^x * 3^(19-x)
# if n is power of 3, then 3^19 = k * n
# since 3 is prime, k and n both should be power of 3, so they should be 3^x & 3^(19-x)
class Solution:
    def isPowerOfThree(self, n: int) -> bool:
        if n <= 0: return False
        return (3 ** 19) % n == 0

# Accepted - O(20)
class Solution1:
    def isPowerOfThree(self, n: int) -> bool:
        if n <= 0: return False
        while n % 3 == 0:  n //= 3
        return n == 1

# Accepted - O(20)
class Solution2:
    def isPowerOfThree(self, n: int) -> bool:
        if n <= 0: return False
        for p in range(20):
            num = 3 ** p
            if num > n: break
            if num == n:return True
        return False