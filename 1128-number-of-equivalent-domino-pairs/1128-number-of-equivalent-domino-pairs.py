class Solution:
    def numEquivDominoPairs(self, dominoes: List[List[int]]) -> int:
        ans = 0
        freq = [0] * 100    # 1 <= dominoes[i][j] <= 9, so 2 dominoes can be represented in 2 digits

        for dom in dominoes:
            dom.sort()
            key = 10 * dom[0] + dom[1]
            ans += freq[key]
            freq[key] += 1

        return ans