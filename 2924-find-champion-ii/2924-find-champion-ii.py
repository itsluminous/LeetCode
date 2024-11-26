class Solution:
    def findChampion(self, n: int, edges: List[List[int]]) -> int:
        if n == 1: return 0   # no competitors

        # 0 = undefined, 1 = weak, 2 = strong
        val = [0] * n
        for src, dest in edges:
            val[dest] = 1
            if val[src] == 0: val[src] = 2

        ans = -1
        for i in range(n):
            if val[i] == 1: continue   # don't care about losers
            if val[i] == 0: return -1  # if we don't know about even a single team, return -1
            if ans != -1: return -1    # we already have one strong team
            ans = i

        return ans