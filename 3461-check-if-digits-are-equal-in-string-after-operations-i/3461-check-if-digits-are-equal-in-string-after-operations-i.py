class Solution:
    def hasSameDigits(self, s: str) -> bool:
        digits = []
        for ch in s:
            digits.append(ord(ch) - ord('0'))

        while len(digits) > 2:
            newDigits = []
            for i in range(len(digits) - 1):
                num1 = digits[i]
                num2 = digits[i+1]
                num3 = (num1 + num2) % 10
                newDigits.append(num3)
            digits = newDigits

        return digits[0] == digits[1]