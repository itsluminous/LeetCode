class Solution:
    def calcEquation(self, equations: List[List[str]], values: List[float], queries: List[List[str]]) -> List[float]:
        # make adjacency list. 
        # Weight of edge connecting nodeA & nodeB is the value of nodeA / nodeB
        graph = self.makeGraph(equations, values);
        ans = [self.getValue(graph, set(), src, dest) for src,dest in queries]
        return ans

    def getValue(self, graph: dict, visited: set, src: str, dest: str) -> float:
        if src not in graph or dest not in graph: return -1.0

        # if the two nodes in question are directly connected, return value directly
        for edge in graph[src]:
            if edge.dest == dest: return edge.weight

        # in case of no direct connection, perform DFS
        # for every edge travelled, the weight will keep multiplying
        visited.add(src)
        for edge in graph[src]:
            if edge.dest in visited: continue
            weight = self.getValue(graph, visited, edge.dest, dest)
            if weight != -1: return edge.weight * weight
        
        # could not find a connection
        return -1.0


    def makeGraph(self, equations: List[List[str]], weights: List[float]) -> dict:
        graph = defaultdict(list)
        for (src, dest), weight in zip(equations, weights):
            graph[src].append(Edge(dest, weight))
            graph[dest].append(Edge(src, 1/weight))
        return graph

class Edge:
    def __init__(self, dest, weight):
        self.dest = dest
        self.weight = weight