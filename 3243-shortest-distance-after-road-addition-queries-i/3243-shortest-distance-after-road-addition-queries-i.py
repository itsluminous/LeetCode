class Solution:
    def shortestDistanceAfterQueries(self, n: int, queries: List[List[int]]) -> List[int]:
        adjList = [[i + 1] for i in range(n)]

        q = len(queries)
        ans = [0] * q
        
        for i, (src, dest) in enumerate(queries):
            adjList[src].append(dest)
            ans[i] = self.bfs(adjList)

        return ans

    def bfs(self, adjList):
        queue = deque([0])

        n = len(adjList)
        visited = [False] * n
        visited[0] = True

        for length in range(n):
            if not queue: break
            for _ in range(len(queue)):
                curr = queue.popleft()
                if curr == n - 1: return length
                for next_node in adjList[curr]:
                    if visited[next_node]: continue
                    visited[next_node] = True
                    queue.append(next_node)
        return 0