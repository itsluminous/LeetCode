class Solution:
    def countGoodNumbers(self, n: int) -> int:
        self.MOD = 1_000_000_007
        oddCount = 4    # can be 2, 3, 5, 7
        evenCount = 5   # can be 0, 2, 4, 6, 8

        oddPos = n // 2         # n/2 positions will have odd index
        evenPos = n - oddPos    # remaining positions are even
        
        return (self.power(oddCount, oddPos) * self.power(evenCount, evenPos)) % self.MOD

    # calculate x^y efficiently
    def power(self, x: int, y: int) -> int:
        ans = 1
        while y > 0:
            if (y & 1) == 1:
                ans = (ans * x) % self.MOD
            
            y >>= 1    # divide y by 2
            x = (x * x) % self.MOD

        return ans % self.MOD