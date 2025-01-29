class Solution:
    def findRedundantConnection(self, edges: List[List[int]]) -> List[int]:
        uf = UnionFind(len(edges) + 1)
        for x,y in edges:
            if not uf.union(x, y):
                return [x, y]
        
        return [0,0]

class UnionFind:
    def __init__(self, n: int):
        self.parent = [0] * n
        for i in range(n):
            self.parent[i] = i  # all are self parent initially
    
    def find(self, node: int) -> int:
        if self.parent[node] != node:
            self.parent[node] = self.find(self.parent[node])
        return self.parent[node]
    
    def union(self, n1: int, n2: int) -> bool:
        n1_p = self.find(n1)
        n2_p = self.find(n2)
        if n1_p == n2_p: return False

        self.parent[n1_p] = self.parent[n2_p]
        return True