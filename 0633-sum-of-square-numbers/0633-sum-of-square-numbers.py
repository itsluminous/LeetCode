class Solution:
    def judgeSquareSum(self, c: int) -> bool:
        num1 = 0
        while num1*num1 <= c:
            num2sq = c - num1*num1
            # if this number is a perfect square, then we have a match
            num2root = sqrt(num2sq)
            if int(num2root) == num2root: return True
            num1 += 1
        return False