class Solution:
    def sumOfTheDigitsOfHarshadNumber(self, x: int) -> int:
        og = x
        sum_of_digits = 0
        while(x != 0):
            sum_of_digits += x%10
            x //= 10
        
        if(og % sum_of_digits == 0):
            return sum_of_digits
        return -1