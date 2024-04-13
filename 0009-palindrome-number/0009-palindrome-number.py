class Solution:
    def isPalindrome(self, x: int) -> bool:
        x_str = str(x)
        for i in range(len(x_str)):
            j = len(x_str) - i - 1
            if x_str[i] != x_str[j]: return False
        return True