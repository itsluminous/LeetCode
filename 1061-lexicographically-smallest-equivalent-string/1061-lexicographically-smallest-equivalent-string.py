class Solution:
    def smallestEquivalentString(self, s1: str, s2: str, baseStr: str) -> str:
        uf = UnionFind()
        for a, b in zip(s1, s2):
            uf.union(a, b)

        return ''.join(uf.find(ch) for ch in baseStr)

class UnionFind:
    def __init__(self):
        self.parent = [chr(i) for i in range(123)]  # // ascii of z is 122

    def find(self, ch):
        if self.parent[ord(ch)] != ch:
            self.parent[ord(ch)] = self.find(self.parent[ord(ch)])  # path compression
        return self.parent[ord(ch)]

    def union(self, a, b):
        pa = self.find(a)
        pb = self.find(b)

        # if both nodes are already connected
        if pa == pb: return

        # keep smaller char as parent
        if pa < pb: self.parent[ord(pb)] = pa
        else: self.parent[ord(pa)] = pb