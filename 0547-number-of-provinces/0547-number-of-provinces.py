class Solution:
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