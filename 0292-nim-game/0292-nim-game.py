# only for multiples of 4, other person can win
class Solution:
    def canWinNim(self, n: int) -> bool:
        return n % 4