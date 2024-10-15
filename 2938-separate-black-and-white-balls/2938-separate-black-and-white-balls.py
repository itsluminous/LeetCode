class Solution:
    def minimumSteps(self, s: str) -> int:
        n, swaps = len(s), 0
        left = right = n-1

        while left >= 0:
            if s[left] == '1':
                swaps += (right - left)
                right -= 1
            left -= 1

        return swaps