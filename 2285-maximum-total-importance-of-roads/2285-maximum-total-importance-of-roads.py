class Solution:
    def maximumImportance(self, n: int, roads: List[List[int]]) -> int:
        # count connections for each city
        connections = [0] * n
        for city1, city2 in roads:
            connections[city1] += 1
            connections[city2] += 1
        
        connections.sort()

        # assign importance. the city with lowest connections will have lowest importance
        imp, total = 1, 0
        for conn in connections:
            total += (conn * imp)
            imp += 1
        return total