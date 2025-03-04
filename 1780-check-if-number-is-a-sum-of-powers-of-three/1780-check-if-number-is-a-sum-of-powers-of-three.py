class Solution:
    def checkPowersOfThree(self, n: int) -> bool:
        # try to represent n in base 3 system
        # eg: 91 = 10101 (3^4 * 1  +  3^3 * 0  + 3^2 * 1  + 3^1 * 0  + 3^0 * 1)
        
        # in base 3 system, we can have either 0 or 1
        # if n % 3 == 2 at any point, it means we need to use same power twice
        while n > 0:
            if n % 3 == 2: return False
            n //= 3
        return True    # n is now 0

# Accepted
class SolutionGreedy:
    def checkPowersOfThree(self, n: int) -> bool:
        # 1, 3, 9, 27, 81, 243, 729, 2187, 6561, 19683, 59049, 177147, 531441, 1594323, 4782969
        length = 15   # 3^15 exceeds 1e7
        powArr = [pow(3, i) for i in range(length)]
        
        idx = length - 1
        while n > 0:
            # subtract curr power if we can
            if n >= powArr[idx]: n -= powArr[idx]
            
            # same power cannot be used twice
            # and it is guaranteed that sum of all smaller powers will always be less than curr power
            if n >= powArr[idx]: return False

            idx -= 1

        return True    # n is now 0