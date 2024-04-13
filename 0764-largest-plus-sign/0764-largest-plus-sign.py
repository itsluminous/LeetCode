class Solution:
    def orderOfLargestPlusSign(self, n: int, mines: List[List[int]]) -> int:
        maxOrder = 0

        isMine = [[False]*n for _ in range(n)]
        for mine in mines:
            isMine[mine[0]][mine[1]] = True

        # store max possible 1s in any direction
        dp = [[0]*n for _ in range(n)]
        for i in range(n):
            # traverse from left to right
            count=0
            for j in range(n):
                count = 0 if isMine[i][j] else count+1
                dp[i][j] = count

            # traverse from right to left
            count=0
            for j in range(n-1, -1, -1):
                count = 0 if isMine[i][j] else count+1
                dp[i][j] = min(dp[i][j], count)

        for i in range(n):
            # traverse from up to down
            count=0
            for j in range(n):
                count = 0 if isMine[j][i] else count+1
                dp[j][i] = min(dp[j][i], count)

            # traverse from down to up
            count=0
            for j in range(n-1, -1, -1):
                count = 0 if isMine[j][i] else count+1
                dp[j][i] = min(dp[j][i], count)
                
                maxOrder = max(maxOrder, dp[j][i])

        return maxOrder