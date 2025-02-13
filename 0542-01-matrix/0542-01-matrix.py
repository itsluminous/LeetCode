class Solution:
    def updateMatrix(self, mat: List[List[int]]) -> List[List[int]]:
        m, n = len(mat), len(mat[0])
        queue = deque()
        
        for i in range(m):
            for j in range(n):
                if mat[i][j] == 0:
                    queue.append((i, j))

        ans = [[0]*n for _ in range(m)]
        if len(queue) == m * n: return ans;    # all are already 0
        
        dirs = [(0, 1), (0, -1), (1, 0), (-1, 0)]
        dist = 0
        while queue:
            dist += 1
            for _ in range(len(queue)):
                x, y = queue.popleft()

                for dx, dy in dirs:
                    nx, ny = x + dx, y + dy
                    if nx < 0 or ny < 0 or nx >= m or ny >= n or mat[nx][ny] == 0: continue
                    mat[nx][ny] = 0
                    ans[nx][ny] = dist
                    queue.append((nx, ny))

        return ans