class Solution:
    def minTimeToReach(self, moveTime: List[List[int]]) -> int:
        m, n = len(moveTime), len(moveTime[0])
        dirs = [(0, 1), (0, -1), (1, 0), (-1, 0)]

        visited = [False] * (m * n)
        pq = [(0, 0, 0)]  # (time, x, y)

        while pq:
            tick, x, y = heappop(pq)
            vis_idx = x * n + y

            if visited[vis_idx]: continue
            visited[vis_idx] = True

            for dx, dy in dirs:
                nx, ny = x + dx, y + dy
                if nx < 0 or ny < 0 or nx == m or ny == n or visited[nx * n + ny]: continue

                max_tick = 1 + max(tick, moveTime[nx][ny])
                if nx == m - 1 and ny == n - 1: return max_tick
                heappush(pq, (max_tick, nx, ny))

        return -1