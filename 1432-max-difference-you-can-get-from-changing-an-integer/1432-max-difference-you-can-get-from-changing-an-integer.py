class Solution:
    def maxDiff(self, num: int) -> int:
        # for 5 digit number like 11891, divisor should be 10000
        digits = floor(log10(num)) # it will give one less count
        divisor = pow(10, digits)

        minNum = maxNum = 0
        minReplace = maxReplace = -1   # digit that needs to be replaced with 0 (for min) or 9 (for max)
        minDigit = 0 if num // divisor == 1 else 1  # first digit should not be 0
        
        while divisor >= 1:
            digit = num // divisor
            num %= divisor
            if divisor == 1: divisor = -1  # we don't want next loop to run
            else: divisor //= 10

            # figure out if this digit should be replaced
            if digit > 1 and minReplace == -1: minReplace = digit
            if digit < 9 and maxReplace == -1: maxReplace = digit

            # if applicable, replace this digit in minNum
            if digit == minReplace: minNum = minNum * 10 + minDigit
            else: minNum = minNum * 10 + digit

            # if applicable, replace this digit in maxNum
            if digit == maxReplace: maxNum = maxNum * 10 + 9
            else: maxNum = maxNum * 10 + digit

        return maxNum - minNum