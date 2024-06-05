class Solution:
    def longestPalindrome(self, s: str) -> int:
        even_count = 0
        chars = set()

        for ch in s:
            if ch in chars:
                chars.remove(ch)
                even_count += 1
            else:
                chars.add(ch)

        even_count *= 2
        if chars: return even_count + 1
        return even_count 