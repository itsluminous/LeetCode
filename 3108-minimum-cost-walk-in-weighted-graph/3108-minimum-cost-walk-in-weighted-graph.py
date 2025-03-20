class Solution:
    def minimumCost(self, n: int, edges: List[List[int]], query: List[List[int]]) -> List[int]:
        uf = UnionFind(n)
        for u,v,w in edges:
            uf.union(u, v, w)
        
        ans = [0] * len(query)
        for i, (u,v) in enumerate(query):
            ans[i] = uf.cost(u, v)

        return ans

class UnionFind:
    def __init__(self, n: int):
        self.andVal = [131071]*n            # 11111111111111111 initially = 131071 (because 0 <= w <= 10^5)
        self.rank = [1] * n                 # equal rank initially
        self.parent = [i for i in range(n)] # self parent initially

    def find(self, v: int) -> int:
        if self.parent[v] == v: return v
        return self.find(self.parent[v])

    def union(self, u: int, v: int, w: int):
        # find parent of u and v
        pu = self.find(u)
        pv = self.find(v)

        # if pv is higher ranked, swap with pu
        # because we will later make pu as parent
        if self.rank[pv] > self.rank[pu]:
            pu, pv = pv, pu
        
        # make pu as self.parent
        self.parent[pv] = pu
        self.rank[pu] += self.rank[pv]
        self.andVal[pu] = self.andVal[pu] & self.andVal[pv] & w

    def cost(self, u: int, v: int) -> int:
        pu = self.find(u)
        pv = self.find(v)

        if pu != pv: return -1 # not connected
        return self.andVal[pu]