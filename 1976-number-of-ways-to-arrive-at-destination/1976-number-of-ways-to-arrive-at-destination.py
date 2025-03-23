class Solution:
    def countPaths(self, n: int, roads: List[List[int]]) -> int:
        MOD = 1_000_000_007
        adj = self.makeGraph(n, roads)
        
        # min dist from 0 to any node
        minDist = [float('inf')] * n
        minDist[0] = 0

        # no. of ways to reach node i
        pathCount = [0] * n
        pathCount[0] = 1

        # start bfs from node 0
        queue = []
        heappush(queue, (0, 0))  # 0 can reach 0 in 0 time

        while queue:
            currDist, currNode = heappop(queue)
            if currDist > minDist[currNode]: continue  # we already found better way to reach this node

            # add next reachable nodes in queue
            for nextNode, nextDist in adj[currNode]:
                nextDist = currDist + nextDist
                if nextDist > minDist[nextNode]: continue  # already found shorter path
                if nextDist == minDist[nextNode]:
                    pathCount[nextNode] = (pathCount[nextNode] + pathCount[currNode]) % MOD
                else:
                    minDist[nextNode] = nextDist
                    pathCount[nextNode] = pathCount[currNode]
                    heappush(queue, (nextDist, nextNode))

        return pathCount[n - 1]

    def makeGraph(self, n: int, roads: list[list[int]]) -> list[list[tuple[int, int]]]:
        adj = defaultdict(list)
        for road in roads:
            u, v, w = road
            adj[u].append((v, w))
            adj[v].append((u, w))
        return adj