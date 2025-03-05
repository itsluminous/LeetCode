# DP with less loops
class Solution:
    def countSubstrings(self, s: str) -> int:
        n, count = len(s), 0
        # dp to check if string with given start & end is palindrome index
        isPalindrome = [[False] * n for _ in range(n)]
        
        for pLen in range(1, n+1):
            start = 0
            for end in range(pLen - 1, n):
                if (pLen <= 2 or  isPalindrome[start+1][end-1]) and s[start] == s[end]:
                    isPalindrome[start][end] = True
                    count += 1
                start += 1

        return count

# Accepted - DP
class SolutionDP:
    def countSubstrings(self, s: str) -> int:
        n = len(s)
        # dp to check if string with given start & end is palindrome index
        isPalindrome = [[False] * n for _ in range(n)]  

        # single char is always palindrome
        count = n
        for i in range(n):
            isPalindrome[i][i] = True
        
        # if 2 consecutive chars is same, then mark it as palindrome
        for i in range(1, n):
            if s[i] == s[i-1]:
                isPalindrome[i-1][i] = True
                count += 1
        
        # check for string length >= 3
        for pLen in range(3, n+1):
            start = 0
            for end in range(pLen - 1, n):
                if isPalindrome[start+1][end-1] and s[start] == s[end]:
                    isPalindrome[start][end] = True
                    count += 1
                start += 1
        
        return count