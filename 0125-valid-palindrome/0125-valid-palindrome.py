class Solution:
    def isPalindrome(self, s: str) -> bool:
        n = len(s)
        i, j = 0, n-1
        while i <= j:
            while i < n and not s[i].isalnum(): i += 1
            while j >= 0 and not s[j].isalnum(): j -= 1
            if i == n or j == -1: return True
            if s[i].lower() != s[j].lower(): return False
            i += 1
            j -= 1
        return True