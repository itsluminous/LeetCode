class Solution:
    def minimumTime(self, grid: List[List[int]]) -> int:
        if grid[0][1] > 1 and grid[1][0] > 1: return -1    # can never move
        
        m, n = len(grid), len(grid[0])
        dirs = [(1, 0), (-1, 0), (0, 1), (0, -1)]
        visited = [[False] * n for _ in range(m)]

        # priority queue to track the next closest cell
        pq = [(0, 0, 0)]    # 0 secs for [0, 0]
        heapq.heapify(pq)

        while pq:
            sec, x, y = heapq.heappop(pq)
            if x == m-1 and y == n-1: return sec

            for dx, dy in dirs:
                newx, newy = x + dx, y + dy
                if not self.isValid(grid, visited, newx, newy): continue
                
                wait = 1 if (grid[newx][newy] - sec) % 2 == 0 else 0   # we will be 1 sec late for even diff
                elapsed = max(grid[newx][newy] + wait, sec + 1)
                heapq.heappush(pq, (elapsed, newx, newy))

        return -1

    def isValid(self, grid, visited, x, y):
        m, n = len(grid), len(grid[0])
        if x < 0 or y < 0 or x >= m or y >= n or visited[x][y]:
            return False

        visited[x][y] = True
        return True