# idea is to keep all matching x & y coordinates in same disjoint set
# for each disjoint set, 1 point will have to be left
class Solution:
    def removeStones(self, stones: List[List[int]]) -> int:
        MAX = 10001
        uf = UnionFind(MAX * 2)    # MAX for x + MAX for y

        for stone in stones:
            uf.union(stone[0], stone[1] + MAX) # offset Y coordinate by MAX so that x & y are distinct
        
        return len(stones) - uf.distinctSetCount

class UnionFind:
    def __init__(self, n: int):
        self.distinctSetCount = 0
        self.uniquePoints = set()
        self.parent = [0] * n
        for i in range(n):
            self.parent[i] = i  # all are self parent initially
    
    def find(self, point: int) -> int:
        if self.parent[point] != point:
            self.parent[point] = self.find(self.parent[point])
        return self.parent[point]
    
    def union(self, p1: int, p2: int):
        # check if we are seeing these points for first time
        self.checkUnique(p1)
        self.checkUnique(p2)

        p1_p = self.find(p1)
        p2_p = self.find(p2)
        if p1_p == p2_p: return

        self.parent[p1_p] = self.parent[p2_p]
        self.distinctSetCount -= 1

    def checkUnique(self, point: int):
        if point not in self.uniquePoints:
            self.uniquePoints.add(point)
            self.distinctSetCount += 1