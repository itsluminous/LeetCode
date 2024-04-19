class Solution:
    def equalPairs(self, grid: List[List[int]]) -> int:
        rows = defaultdict(int)
        m, n, count = len(grid), len(grid[0]), 0

        for i in range(m):
            key = " : ".join(str(grid[i][j]) for j in range(n))
            rows[key] += 1
        
        for i in range(m):
            key = " : ".join(str(grid[j][i]) for j in range(n))
            count += rows[key]
        
        return count