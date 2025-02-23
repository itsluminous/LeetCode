class Solution:
    def maxSum(self, grid: List[List[int]], limits: List[int], k: int) -> int:
        # find all biggest numbers in each row, within limit
        biggest = []
        for i, row in enumerate(grid):
            row.sort(reverse = True)
            for j in range(limits[i]):
                biggest.append(grid[i][j])

        # pick top k numbers from biggest numbers
        biggest.sort(reverse = True)
        ans = 0
        for i in range(k):
            ans += biggest[i]

        return ans