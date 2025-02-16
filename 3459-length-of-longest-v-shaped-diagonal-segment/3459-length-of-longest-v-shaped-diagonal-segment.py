class Solution:
    def lenOfVDiagonal(self, grid: List[List[int]]) -> int:
        def pathLen(x, y, num, dirIdx, hasTurned):
            if x == -1 or y == -1 or x == m or y == n: return 0
            if grid[x][y] != num: return 0

            key = (x, y, dirIdx, hasTurned)
            if key in dp: return dp[key]

            count = pathLen(x + dirs[dirIdx][0], y + dirs[dirIdx][1], nextNum[num], dirIdx, hasTurned)
            if hasTurned == 0:
                dir2Idx = (dirIdx + 1) % 4
                countTurn = pathLen(x + dirs[dir2Idx][0], y + dirs[dir2Idx][1], nextNum[num], dir2Idx, 1)
                count = max(count, countTurn)
            
            dp[key] = 1 + count
            return dp[key]
        
        m, n = len(grid), len(grid[0])
        dirs = [[1,1], [1,-1], [-1,-1],[-1,1]]
        nextNum = [2, 2, 0] # 0 -> 2 -> 0
        maxCount = 0
        dp = {}

        for i in range(m):
            for j in range(n):
                if grid[i][j] != 1: continue
                
                count = 0
                for dirIdx in range(4):
                    count = max(count, pathLen(i, j, 1, dirIdx, 0))
                maxCount = max(maxCount, count)
        
        return maxCount