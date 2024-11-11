class Solution:
    def primeSubOperation(self, nums: List[int]) -> bool:
        if len(nums) == 1: return True
        maxVal = max(nums)
        isPrime = self.checkPrimes(maxVal+1)

        # target is what we want num to become, idx is curr index being processed in nums
        target, idx = 1, 0
        while idx < len(nums):
            diff = nums[idx] - target
            if diff < 0: return False  # the num cannot be converted to prime bigger than prev
            if diff == 0 or isPrime[diff]:
                idx += 1  # this index is successfully converted
            target += 1
        return True

    def checkPrimes(self, n):
        isPrime = [False] * n
        for i in range(3, n, 2): isPrime[i] = True  # mark all odd nums as prime
        isPrime[2] = True  # mark 2 as prime, other even nums will be false

        sqrt = math.ceil(math.sqrt(n))
        for i in range(3, sqrt, 2):
            if not isPrime[i]: continue
            j = i*i
            while j < n:
                isPrime[j] = False
                j+=2*i

        return isPrime