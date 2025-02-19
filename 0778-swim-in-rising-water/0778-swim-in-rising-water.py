class Solution:
    def swimInWater(self, grid: List[List[int]]) -> int:
        n = len(grid)
        dirs = [(0, 1), (0, -1), (1, 0), (-1, 0)]

        # x, y, timeNeeded - sorted by time needed
        pq = []
        heappush(pq, [grid[0][0], 0, 0])
        grid[0][0] = -1    # visited

        while pq:
            t, x, y = heappop(pq)
            if x == n-1 and y == n-1: return t

            for dx, dy in dirs:
                nx, ny = x + dx, y + dy
                if nx == -1 or ny == -1 or nx == n or ny == n or grid[nx][ny] == -1: continue
                
                tt = max(t, grid[nx][ny]) # time needed to reach here
                heappush(pq, [tt, nx, ny])
                grid[nx][ny] = -1    # visited

        return 0   # will never reach here