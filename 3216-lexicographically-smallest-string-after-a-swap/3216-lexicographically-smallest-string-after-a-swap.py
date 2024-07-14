class Solution:
    def getSmallestString(self, s: str) -> str:
        chars = list(s)
        for i in range(len(chars)-1):
            if chars[i] > chars[i+1]:
                num1 = ord(chars[i]) - ord('0')
                num2 = ord(chars[i+1]) - ord('0')
                if (num1 & 1) == (num2 & 1):
                    chars[i], chars[i+1] = chars[i+1], chars[i]
                    break

        return ''.join(chars)