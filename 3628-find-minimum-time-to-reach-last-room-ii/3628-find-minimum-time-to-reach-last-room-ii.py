class Solution:
    def minTimeToReach(self, moveTime: List[List[int]]) -> int:
        m, n = len(moveTime), len(moveTime[0])
        dirs = [(0,1), (0,-1), (1,0), (-1,0)]

        minTime = [0] * (m * n)
        pq = [(0, 0, 0, 0)]  # [time, extra, x, y] => extra = 1 if next step needs 2 secs

        while pq:
            tick, extra, x, y = heappop(pq)
            minTimeIdx = x * n + y

            if not (x == 0 and y == 0) and minTime[minTimeIdx] > 0: continue    # already processed with better time
            if x == m - 1 and y == n - 1: return tick                           # found destination
            minTime[minTimeIdx] = tick

            for dx, dy in dirs:
                nx, ny = x + dx, y + dy
                if nx < 0 or ny < 0 or nx >= m or ny >= n: continue             # out of bounds
                nextTick = 1 + extra + max(tick, moveTime[nx][ny])
                nextIdx = nx * n + ny
                if minTime[nextIdx] > 0 and minTime[nextIdx] <= nextTick: continue
                heappush(pq, (nextTick, 1 - extra, nx, ny))

        return -1   # unreachable