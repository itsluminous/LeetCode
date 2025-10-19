class Solution:
    def findLexSmallestString(self, s: str, a: int, b: int) -> str:
        self.seen = set()
        self.ans = s
        self.dfs(s, a, b)
        return self.ans

    def dfs(self, s: str, a: int, b: int):
        if s in self.seen: return
        if s < self.ans: self.ans = s
        self.seen.add(s)
        self.dfs(self.add(s, a), a, b)
        self.dfs(self.rotate(s, b), a, b)

    def add(self, s: str, a: int) -> str:
        s_list = list(s)
        for i in range(1, len(s_list), 2):
            s_list[i] = str((int(s_list[i]) + a) % 10)
        return ''.join(s_list)

    def rotate(self, s: str, b: int) -> str:
        return s[-b:] + s[:-b]
