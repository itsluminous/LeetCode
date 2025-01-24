class Solution:
    def eventualSafeNodes(self, graph: List[List[int]]) -> List[int]:
        n = len(graph)
        visited = [False] * n
        safeMap = {}
        
        def isSafe(node: int) -> bool:
            # terminal node is always safe
            if len(graph[node]) == 0:
                safeMap[node] = True
                return True
            
            # already evaluated node
            if node in safeMap: return safeMap[node]

            # revisiting a node is unsafe
            if visited[node]:
                safeMap[node] = False
                return False
            visited[node] = True
            
            # check if all paths are safe
            currSafe = True
            for dest in graph[node]:
                currSafe &= isSafe(dest)
                if not currSafe: break
            
            safeMap[node] = currSafe
            visited[node] = False
            return currSafe
        
        safeNodes = []
        for i in range(n):
            if isSafe(i): safeNodes.append(i)

        return safeNodes
