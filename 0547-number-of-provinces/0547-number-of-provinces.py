class Solution:
    def findCircleNum(self, isConnected: List[List[int]]) -> int:
        n = len(isConnected)
        uf = UnionFind(n)

        for i in range(n-1):
            for j in range(i+1, n):
                if isConnected[i][j] == 1:
                    uf.union(i, j)

        return uf.count

class UnionFind:
    def __init__(self, n):
        self.count = n
        self.rank = [0] * n
        self.parent = list(range(n))

    def union(self, n1: int, n2: int):
        p1 = self.find(n1)
        p2 = self.find(n2)
        if p1 == p2: return

        if self.rank[p1] > self.rank[p2]:
            self.parent[p2] = p1
        else:
            self.parent[p1] = p2
            if self.rank[p1] == self.rank[p2]:
                self.rank[p2] += 1
        self.count -= 1

    def find(self, node: int) -> int:
        p = self.parent[node]
        if p == node:
            return p
        return self.find(p)

# Accepted
class SolutionDFS:
    def findCircleNum(self, isConnected: List[List[int]]) -> int:
        n, province = len(isConnected), 0
        self.visited = [False] * (n+1)
        for city in range(n):
            if self.dfs(isConnected, city):
                province += 1
        return province
    
    def dfs(self, isConnected: List[List[int]], city: int) -> bool:
        if self.visited[city]: return False
        self.visited[city] = True

        for next in range(len(isConnected)):
            if isConnected[city][next] == 0: continue
            self.dfs(isConnected, next)
        return True