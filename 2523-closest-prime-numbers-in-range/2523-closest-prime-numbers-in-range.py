class Solution:
    def closestPrimes(self, left: int, right: int) -> List[int]:
        ans = [-1, -1]
        if right <= 2 or left == right: return ans    # not possible to have 2 primes

        prime_num = self.findPrimes(right + 1)
        firstPrime = self.nextPrime(prime_num, left, right)
        if firstPrime == -1: return ans

        diff = right - left + 1 # basically infinity
        while firstPrime < right:
            secondPrime = self.nextPrime(prime_num, firstPrime + 1, right)
            if secondPrime == -1: break # no other prime exists
            
            if secondPrime - firstPrime < diff:
                diff = secondPrime - firstPrime
                ans = [firstPrime, secondPrime]
            
            firstPrime = secondPrime
        
        return ans
    
    # get next prime by looping through prime_num array
    def nextPrime(self, prime_num: List[bool], left: int, right: int) -> int:
        for i in range(left, right + 1):
            if prime_num[i]: return i
        
        return -1
    
    # Sieve Of Eratosthenes
    def findPrimes(self, n: int) -> List[int]:
        isPrime = [False] * n
        isPrime[2] = True           # mark 2 as prime
        for i in range(3, n, 2):    # mark all odd nums as prime
            isPrime[i] = True
        
        sqrt = math.ceil(n ** 0.5)
        for num in range(3, sqrt, 2):
            if not isPrime[num]: continue
            idx = num * num
            while idx < n:
                isPrime[idx] = False
                idx += 2 * num
        
        return isPrime