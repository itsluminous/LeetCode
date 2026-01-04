# it is guaranteed that if col x in a row is k, then col x in row-1 will be >= k
# so we start from bottom row, left col and move right till we find negative
# once we find -ve, the row above will for sure not have a negative before this col idx
class Solution:
    def countNegatives(self, grid: List[List[int]]) -> int:
        m, n = len(grid), len(grid[0])

        # start from bottom left
        r, c, ans = m-1, 0, 0
        while r >= 0 and c < n:
            if grid[r][c] < 0:
                r -= 1
                ans += n - c   # m - c negative in current row
            else:
                c += 1
        return ans