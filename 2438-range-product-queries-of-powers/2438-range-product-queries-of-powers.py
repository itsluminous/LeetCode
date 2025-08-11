# all the set bits in n represent min powers of two
class Solution:
    def productQueries(self, n: int, queries: List[List[int]]) -> List[int]:
        MOD = 1_000_000_007;
        powers = []
        for i in range(30):
            if n == 0: break
            if (n & 1) == 1: powers.append(2 ** i)
            n >>= 1

        ans = []
        for query in queries:
            prod = 1
            for i in range(query[0], query[1] + 1):
                prod = (prod * powers[i]) % MOD
            ans.append(prod)

        return ans