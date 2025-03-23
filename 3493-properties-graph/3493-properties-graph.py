class Solution:
    def numberOfComponents(self, properties: List[List[int]], k: int) -> int:
        n = len(properties)
        propUniqNums = [set(prop) for prop in properties]
        
        uf = UnionFind(n)
        for i in range(n):
            for j in range(i+1, n):
                intersectCount = self.computeIntersection(propUniqNums[i], propUniqNums[j])
                if intersectCount >= k:
                    uf.union(i, j)
        
        return uf.countComponents()

    def computeIntersection(self, a, b) -> int:
        count = 0
        if len(a) > len(b):
            temp = a
            a = b
            b = temp
        
        for num in a:
            if num in b:
                count += 1

        return count

class UnionFind:
    def __init__(self, n):
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

    def find(self, node: int) -> int:
        if self.parent[node] != node:
            self.parent[node] = self.find(self.parent[node])
        return self.parent[node]

    def countComponents(self) -> int:
        count = 0
        for i, p in enumerate(self.parent):
            if p == i:
                count += 1
        return count