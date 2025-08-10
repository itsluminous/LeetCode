class Solution:
    def reorderedPowerOf2(self, n: int) -> bool:
        n_freq = self.count(n)
        # now match this freq with all possible powers of 2
        # loop till 29 only because power 30 gives > 10^9 
        for i in range(30):
            curr_count = self.count(1 << i)
            if n_freq == curr_count:
                return True
        return False

    # freq of each digit 0-9 in the number
    # since 1 <= N <= 10^9, so up to 8 same digits, hence we can skip using array for counting and use a base10 number
    def count(self, n: int) -> int:
        n_freq = 0
        while n > 0:
            n_freq += 10 ** (n % 10)
            n //= 10
        return n_freq

# Accepted - using array for freq counting
class SolutionFreqArr:
    def reorderedPowerOf2(self, n: int) -> bool:
        digits = self.count(n)
        # now match this freq with all possible powers of 2
        # loop till 29 only because power 30 gives > 10^9 
        for i in range(30):
            curr_count = self.count(1 << i)
            if digits == curr_count:
                return True
        return False

    # freq of each digit 0-9 in the number
    def count(self, n: int) -> list:
        digits = [0] * 10
        while n > 0:
            digits[n % 10] += 1
            n //= 10
        return digits
