class Solution:
    def getNoZeroIntegers(self, n: int) -> List[int]:
        num1, num2, mul = 0, 0, 1
        while n > 0:
            digit = n % 10
            n //= 10

            # treat 0 & 1 as 10 & 11
            # need to check n>0 to handle case where just carry can fill next digit (eg. n = 19)
            if digit < 2 and n > 0:
                num1 += mul * 9
                num2 += mul * (1 + digit)  # same as mul * (10 + digit - 9)
                n -= 1    # handle carry
            else:
                num1 += mul * 1
                num2 += mul * (digit - 1)
            mul *= 10

        return [num1, num2]