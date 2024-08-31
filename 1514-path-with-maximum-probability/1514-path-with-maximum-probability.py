class Solution:
    def maxProbability(self, n: int, edges: List[List[int]], succProb: List[float], start_node: int, end_node: int) -> float:
        graph = self.buildGraph(n, edges, succProb)
        if not graph[start_node] or not graph[end_node]: return 0.0   # if it is not connected

        visited = [False] * n
        visited[start_node] = True

        queue = []
        for e in graph[start_node]: heappush(queue, e)

        # BFS
        while queue:
            e = heappop(queue)
            if e.dest == end_node: return e.prob
            visited[e.dest] = True

            for ed in graph[e.dest]:
                if visited[ed.dest]: continue
                heappush(queue, Edge(ed.dest, ed.prob * e.prob))

        return 0.0

    def buildGraph(self, n: int, edges: List[List[int]], succProb: List[float]) -> dict:
        graph = defaultdict(list)

        for i in range(len(edges)):
            src, dest = edges[i]
            graph[src].append(Edge(dest, succProb[i]))
            graph[dest].append(Edge(src, succProb[i]))
        return graph

class Edge:
    def __init__(self, d, p):
        self.dest = d
        self.prob = p
    
    def __lt__(self, other):
        return self.prob > other.prob