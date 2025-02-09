class Solution:
    def sortMatrix(self, grid: List[List[int]]) -> List[List[int]]:
        n = len(grid)

        # upper right diagonal
        for k in range(n-1, 0, -1):
            nums = []
            i = 0
            for j in range(k, n):
                nums.append(grid[i][j])
                i += 1
            nums.sort()
            idx=0
            i = 0
            for j in range(k, n):
                grid[i][j] = nums[idx]
                i += 1
                idx += 1

        # lower left diagonal
        for k in range(0, n):
            nums = []
            i = k
            for j in range(0, n-k):
                nums.append(grid[i][j])
                i += 1
            nums.sort()
            idx=1
            i = k
            for j in range(0, n-k):
                grid[i][j] = nums[-idx]
                i += 1
                idx += 1

        return grid