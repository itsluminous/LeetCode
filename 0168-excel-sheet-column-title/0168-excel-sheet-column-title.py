class Solution:
    def convertToTitle(self, columnNumber: int) -> str:
        ans = ""
        while columnNumber > 0:
            columnNumber -= 1
            remainder = columnNumber % 26
            columnNumber = columnNumber // 26

            ch = chr(ord("A") + remainder)
            ans += ch

        return ans[::-1]