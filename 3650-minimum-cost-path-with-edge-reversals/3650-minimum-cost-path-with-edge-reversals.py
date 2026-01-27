class Solution:
    def minCost(self, n: int, edges: List[List[int]]) -> int:
        edge_list = [[] for _ in range(n)]
        for u, v, w in edges:
            edge_list[u].append((v, w))
            edge_list[v].append((u, 2 * w))

        # Dijkstra
        visited = [False] * n
        min_dist = [float('inf')] * n
        min_dist[0] = 0

        pq = [(0, 0)]   # [distance, node]
        heapq.heapify(pq)

        while pq:
            dist, node = heapq.heappop(pq)
            if node == n - 1: return dist  # reached destination
            if visited[node]: continue

            visited[node] = True
            for nd, wt in edge_list[node]:
                if min_dist[nd] > dist + wt:
                    min_dist[nd] = dist + wt
                    heapq.heappush(pq, (min_dist[nd], nd))

        return -1