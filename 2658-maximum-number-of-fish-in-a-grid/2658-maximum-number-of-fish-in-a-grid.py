class Solution:
    def findMaxFish(self, grid: List[List[int]]) -> int:
        m, n = len(grid), len(grid[0])
        self.dirs = [[0,1], [1,0], [0,-1], [-1,0]]
        self.visited = [[False] * n for _ in range(m)]
        maxFish = 0

        for i in range(m):
            for j in range(n):
                if grid[i][j] == 0 or self.visited[i][j]: continue
                maxFish = max(maxFish, self.bfs(grid, i, j))

        return maxFish

    def bfs(self, grid, x, y) -> int:
        m, n = len(grid), len(grid[0])

        queue = deque()
        queue.append((x, y))
        self.visited[x][y] = True
        count = grid[x][y]

        while queue:
            x, y = queue.popleft()
            for dx, dy in self.dirs:
                xx, yy = x + dx, y + dy
                if xx == -1 or yy == -1 or xx == m or yy == n or grid[xx][yy] == 0 or self.visited[xx][yy]: continue
                queue.append((xx, yy))
                self.visited[xx][yy] = True
                count += grid[xx][yy]

        return count