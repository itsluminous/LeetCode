class Solution:
    def findDiagonalOrder(self, mat: List[List[int]]) -> List[int]:
        m, n = len(mat), len(mat[0])
        r = c = d = 0
        ans = [0] * (m*n)

        dirs = [[-1, 1], [1, -1]]

        for idx in range(m*n):
            ans[idx] = mat[r][c]
            nr = r + dirs[d][0]
            nc = c + dirs[d][1]

            if nr == -1 or nc == -1 or nr == m or nc == n:
                if d == 0: # going up
                    r += 1 if c == n-1 else 0    # move row down
                    c += 1 if c < n-1 else 0     # move col right
                else:  # going down
                    c += 1 if r == m-1 else 0    # move col right
                    r += 1 if r < m-1 else 0     # move row down

                d = 1 - d # change dir
            else:
                r = nr
                c = nc

        return ans