class Solution:
    def longestPalindromicSubsequence(self, s: str, k: int) -> int:
        n = len(s)

        @cache
        def getChangeCost(ch1, ch2):
            pos1 = ord(ch1) - ord('a')
            pos2 = ord(ch2) - ord('a')
            forward = (pos2 - pos1 + 26) % 26
            backward = (pos1 - pos2 + 26) % 26
            return min(forward, backward)

        @cache
        def longestPalindrome(i, j, k):
            if i > j: return 0
            if i == j: return 1

            ans = 0
            if s[i] == s[j]:
                ans = 2 + longestPalindrome(i+1, j-1, k)
            else:
                cost = getChangeCost(s[i], s[j])
                option1 = 0
                if k >= cost:
                    option1 = 2 + longestPalindrome(i+1, j-1, k-cost)
                
                option2 = longestPalindrome(i+1, j, k)
                option3 = longestPalindrome(i, j-1, k)
                ans = max(option1, option2, option3)
                
            return ans
        
        return longestPalindrome(0, len(s)-1, k)