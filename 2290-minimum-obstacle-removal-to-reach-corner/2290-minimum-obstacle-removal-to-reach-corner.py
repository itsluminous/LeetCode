class Solution:
    def minimumObstacles(self, grid: List[List[int]]) -> int:
        m, n = len(grid), len(grid[0])
        
        # matrix to track how many steps it took to reach each point
        obs = [[100001] * n for _ in range(m)]
        obs[0][0] = grid[0][0]  # if [0,0] is obstacle, then we need to remove 1 obstacle 

        # queue for BFS, to reach [m-1, n-1]
        queue = deque([(0, 0)])

        while queue:
            x, y = queue.popleft()
            # Up
            if x > 0 and obs[x][y] + grid[x-1][y] < obs[x-1][y]:
                obs[x-1][y] = obs[x][y] + grid[x-1][y]
                queue.append((x-1, y))
            # Down
            if x < m-1 and obs[x][y] + grid[x+1][y] < obs[x+1][y]:
                obs[x+1][y] = obs[x][y] + grid[x+1][y]
                queue.append((x+1, y))
            # Left
            if y > 0 and obs[x][y] + grid[x][y-1] < obs[x][y-1]:
                obs[x][y-1] = obs[x][y] + grid[x][y-1]
                queue.append((x, y-1))
            # Right
            if y < n-1 and obs[x][y] + grid[x][y+1] < obs[x][y+1]:
                obs[x][y+1] = obs[x][y] + grid[x][y+1]
                queue.append((x, y+1))

        return obs[m-1][n-1]