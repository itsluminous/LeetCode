class Solution:
    def largestLocal(self, grid: List[List[int]]) -> List[List[int]]:
        n = len(grid)
        ans = [[0]*(n-2) for _ in range(n-2)]

        for i in range(1, n-1):
            for j in range(1, n-1):
                for x in range(-1, 2):
                    for y in range(-1, 2):
                        ans[i-1][j-1] = max(ans[i-1][j-1], grid[i+x][j+y])
        return ans