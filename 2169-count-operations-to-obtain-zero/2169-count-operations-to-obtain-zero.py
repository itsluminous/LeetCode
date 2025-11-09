class Solution:
    def countOperations(self, num1: int, num2: int) -> int:
        ans = 0

        while num1 and num2:
            ans += num1 // num2 #  we may have to subtract num2 multiple times, so taking shortcut
            num1 %= num2
            num1, num2 = num2, num1    # swap numbers

        return ans