# the robot can only touch m-1 + n-1 cells in grid, no matter what path you take
# these (m+n-2) paths can vary based on when you take down vs when you take right
# so possible ways to touch these cells are (m+n-2)C(m-1)
# i.e. (m+n-2)! / (m-1)! * (n-1)!
# refer https://betterexplained.com/articles/easy-permutations-and-combinations/
class Solution:
    def uniquePaths(self, m: int, n: int) -> int:
        ans = j = 1
        for i in range(m+n-2, max(m,n) - 1, -1):
            ans = (ans * i) // j
            j += 1
        return ans

# accepted O(m*n)
class SolutionN2:
    def uniquePaths(self, m: int, n: int) -> int:
        dp = [[1 for _ in range(n)] for _ in range(m)]

        # for every other cell, it can either be reached from above one or left one
        for i in range(1, m):
            for j in range(1, n):
                print(f'dp[{i}][{j}]')
                dp[i][j] = dp[i-1][j] + dp[i][j-1]
        
        return dp[-1][-1]