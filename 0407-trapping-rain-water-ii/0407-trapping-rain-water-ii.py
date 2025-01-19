# explaination : https://leetcode.com/problems/trapping-rain-water-ii/solutions/1138028/python3-visualization-bfs-solution-with-explanation
class Solution:
    def trapRainWater(self, heightMap: List[List[int]]) -> int:
        m, n = len(heightMap), len(heightMap[0])
        dirs = [(0, 1), (0, -1), (1, 0), (-1, 0)]
        
        # pq will always give smallest height cell, and then we check if its neighbours can trap water
        # we add all boundary cells to pq because they cannot trap water
        pq = self.pqWithBoundaryCells(heightMap)

        # look at neighbours of all cells one by one
        trapped = level = 0
        while pq:
            height, x, y = heapq.heappop(pq)
            level = max(level, height)

            # check all neighbours
            for dx, dy in dirs:
                xx, yy = x + dx, y + dy
                if xx == -1 or yy == -1 or xx == m or yy == n or heightMap[xx][yy] == -1: continue

                if heightMap[xx][yy] < level: trapped += level - heightMap[xx][yy] # can trap water
                heapq.heappush(pq, (heightMap[xx][yy], xx, yy))
                heightMap[xx][yy] = -1

        return trapped

    def pqWithBoundaryCells(self, heightMap):
        m, n = len(heightMap), len(heightMap[0])
        pq = []

        for i in range(m):
            heapq.heappush(pq, (heightMap[i][0], i, 0))
            heightMap[i][0] = -1
            heapq.heappush(pq, (heightMap[i][n-1], i, n-1))
            heightMap[i][n-1] = -1
        
        for j in range(n):
            heapq.heappush(pq, (heightMap[0][j], 0, j))
            heightMap[0][j] = -1
            heapq.heappush(pq, (heightMap[m-1][j], m-1, j))
            heightMap[m-1][j] = -1

        return pq