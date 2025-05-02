class Solution:
    def pushDominoes(self, dominoes: str) -> str:
        n, l = len(dominoes), 0
        ans = []
        lchar = '.'  # it can be '.' or 'R'

        for r in range(n):
            # no action for just "."
            if dominoes[r] == '.': continue

            # if we encounter "R", then if l="R", then all followers will be "R", else all "."
            if dominoes[r] == 'R':
                for i in range(l, r): ans.append(lchar)
                lchar = 'R'
                l = r

            # if we encounter "L" and l=".", then all dominoes between l and r will fall on left
            # if we encounter "L" and l="R", then dominoes will fall from both sides
            if dominoes[r] == 'L':
                if lchar == '.':
                    for i in range(l, r + 1): ans.append('L')
                    l = r + 1
                else:
                    diff = r - l + 1
                    for i in range(diff // 2): ans.append('R')
                    if diff % 2 == 1: ans.append('.')
                    for i in range(diff // 2): ans.append('L')
                    
                    l = r + 1
                    lchar = '.'

        # take care of remaining dominoes
        if l < n:
            for i in range(l, n): ans.append(lchar)

        return ''.join(ans)