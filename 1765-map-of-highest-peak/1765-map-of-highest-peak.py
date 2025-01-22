class Solution:
    def highestPeak(self, isWater: List[List[int]]) -> List[List[int]]:
        m, n = len(isWater), len(isWater[0])
        queue = deque()
        for i in range(m):
            for j in range(n):
                if isWater[i][j] == 1:
                    queue.append((i, j))
                    isWater[i][j] = -1  # set all water to -1 to differentiate it

        waters = list(queue)
        dirs = [(0, -1), (0, 1), (-1, 0), (1, 0)]

        height = 1
        while queue:
            for _ in range(len(queue)):
                x, y = queue.popleft()
                for dx, dy in dirs:
                    xx, yy = x + dx, y + dy
                    if xx == -1 or yy == -1 or xx == m or yy == n or isWater[xx][yy] != 0:
                        continue

                    queue.append((xx, yy))
                    isWater[xx][yy] = height
            height += 1

        # change all water from -1 to 0
        for x, y in waters:
            isWater[x][y] = 0

        return isWater