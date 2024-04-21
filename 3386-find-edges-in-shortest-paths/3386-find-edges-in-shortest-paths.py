class Solution:
    def findAnswer(self, n: int, edges: List[List[int]]) -> List[bool]:
        graph = self.edges_to_graph(n, edges)
        shortest_path_edges = self.dijkstra(graph)
        
        # now check which edges are part of the shortest path
        ans = [False] * len(edges)
        for i in range(len(edges)):
            s, d, w = edges[i]
            if (s, d) in shortest_path_edges or (d, s) in shortest_path_edges:
                ans[i] = True
        
        return ans

    # function to covert edges to adjacency list
    def edges_to_graph(self, n, edges):
        graph = [[] for _ in range(n)]
        for s, d, w in edges:
            graph[s].append((d, w))
            graph[d].append((s, w))
        
        return graph

    # function to find shortest distance to reach each node
    def dijkstra(self, graph):
        n = len(graph)
        
        # shortest distance to reach each node
        shortest_dist = [inf] * n
        shortest_dist[0] = 0  # can reach node 0 in 0 distance, because we start from there

        pq = [(0, 0)]  # Starting from node 0 with distance 0

        # use Dijkstra to find shortest weight for reaching each node
        while pq:
            node, dist = heappop(pq)

            if dist > shortest_dist[node]: continue
            
            for neighbor, weight in graph[node]:
                if shortest_dist[node] + weight >= shortest_dist[neighbor]:
                    continue
                shortest_dist[neighbor] = shortest_dist[node] + weight
                heappush(pq, (neighbor, shortest_dist[neighbor]))

        # starting from last node, find the shortest routes to reach node 0
        shortest_path_edges = set()
        queue = [n - 1]
        while queue:
            node = queue.pop()
            for neighbor, weight in graph[node]:
                if shortest_dist[node] != inf and shortest_dist[neighbor] != inf \
                and shortest_dist[node] - weight == shortest_dist[neighbor]:
                    shortest_path_edges.add((node, neighbor))
                    queue.append(neighbor)

        return shortest_path_edges