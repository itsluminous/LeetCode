class Solution:
    def isBipartite(self, graph: List[List[int]]) -> bool:
        n = len(graph)
        colors = [0] * n

        def isValid(node, color):
            # if already colored, then check if it matches expectation
            if colors[node] != 0:
                return colors[node] == color
            
            colors[node] = color
            
            # try to color all neighbours in opposite color
            for next in graph[node]:
                if not isValid(next, -color):
                    return False
            return True

        for i in range(n):
            if colors[i] == 0 and not isValid(i, 1):
                return False
        return True