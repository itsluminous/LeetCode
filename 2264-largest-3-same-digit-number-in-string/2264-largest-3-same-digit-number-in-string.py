class Solution:
    def largestGoodInteger(self, num: str) -> str:
        maxChar = '#';  # any char before 0 in ascii
        for i in range(len(num) - 2):
            if num[i] == num[i+1] and num[i] == num[i+2]:
                maxChar = max(maxChar, num[i])

        if maxChar == '#': return ""
        return maxChar * 3