class Solution:
    def checkIfPrerequisite(self, n: int, prerequisites: List[List[int]], queries: List[List[int]]) -> List[bool]:
        connected = [[False] * n for _ in range(n)]
        for i, j in prerequisites:
            connected[i][j] = True
        
        for middle in range(n):
            for src in range(n):
                for dest in range(n):
                    connected[src][dest] = connected[src][dest] or (connected[src][middle] and connected[middle][dest])
        
        return [connected[i][j] for i, j in queries]