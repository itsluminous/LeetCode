class Solution:
    def rotateTheBox(self, box: List[List[str]]) -> List[List[str]]:
        m, n = len(box), len(box[0])
        ans = [['.' for _ in range(m)] for _ in range(n)]

        for i in range(m):
            r=n-1
            for l in range(n-1, -1, -1):
                if box[i][l] == '*':
                    # all cells till this point will be empty
                    ans[l][m-i-1] = '*'
                    r = l-1
                elif box[i][l] == '#':
                    # this stone should fall to rightmost possible idx
                    ans[r][m-i-1] = '#'
                    r -= 1
        return ans