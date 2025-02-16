class Solution:
    def hasSpecialSubstring(self, s: str, k: int) -> bool:
        count = 1
        for i in range(1, len(s)):
            if s[i] == s[i-1]:
                count += 1
            elif count == k:
                return True
            else:
                count = 1

        return count == k