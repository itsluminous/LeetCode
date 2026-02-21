# 10^6 = 11110100001001000000
# so we can have max 19 bits set
# prime numbers in this range are : 2, 3, 5, 7, 11, 13, 17, 19

class Solution:
    def countPrimeSetBits(self, left: int, right: int) -> int:
        primes = {2, 3, 5, 7, 11, 13, 17, 19}
        return sum((num.bit_count() in primes) for num in range(left, right + 1))