class Solution:
    def orangesRotting(self, grid: List[List[int]]) -> int:
        m, n, fresh = len(grid), len(grid[0]), 0
        rottenIdx = deque()
        
        for i in range(m):
            for j in range(n):
                if grid[i][j] == 1:
                    fresh += 1
                elif grid[i][j] == 2:
                    rottenIdx.append((i, j))

        if fresh == 0: return 0  # nothing is fresh
        if not rottenIdx: return -1  # no rotten, no conversion possible
        
        dirs = [(0, 1), (0, -1), (1, 0), (-1, 0)]
        minute = 1
        while rottenIdx:
            for _ in range(len(rottenIdx)):
                x, y = rottenIdx.popleft()

                for dx, dy in dirs:
                    nx, ny = x + dx, y + dy
                    if nx < 0 or ny < 0 or nx >= m or ny >= n or grid[nx][ny] != 1: continue
                    
                    fresh -= 1
                    grid[nx][ny] = 0
                    rottenIdx.append((nx, ny))

            if fresh == 0: return minute
            minute += 1

        return -1