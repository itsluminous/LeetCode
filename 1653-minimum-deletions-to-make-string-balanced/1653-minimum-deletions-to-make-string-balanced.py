class Solution:
    def minimumDeletions(self, s: str) -> int:
        minDel = b = 0
        for ch in s:
            if ch == 'b':
                b += 1
            else:
                minDel = min(minDel + 1, b)

        return minDel