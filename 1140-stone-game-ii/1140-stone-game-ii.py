class Solution:
    def stoneGameII(self, piles: List[int]) -> int:
        n = len(piles)
        # create suffix sum (directly modify piles array)
        for i in range(n-2, -1, -1):
            piles[i] += piles[i+1]
        
        @lru_cache(None)
        def score(m: int, idx: int) -> int:
            if idx + 2*m >= n: return piles[idx]    # last player takes it all

            maxScore = 0
            for i in range(1, 2*m + 1):
                take = piles[idx] - piles[idx+i]
                leftover = piles[idx+i] - score(max(m, i), idx+i)
                maxScore = max(maxScore, take + leftover)
            return maxScore
        
        return score(1, 0)