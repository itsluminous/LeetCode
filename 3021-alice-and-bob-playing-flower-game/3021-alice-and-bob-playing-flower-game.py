class Solution:
    def flowerGame(self, n: int, m: int) -> int:
        nOdd = ((n // 2) * (m // 2)) if n % 2 == 0 else ((n // 2 + 1) * (m // 2))
        mOdd = ((m // 2) * (n // 2)) if m % 2 == 0 else ((m // 2 + 1) * (n // 2))
        
        return nOdd + mOdd  # Alice can win only when x+y is odd number