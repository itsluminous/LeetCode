class Solution:
    def queryResults(self, limit: int, queries: List[List[int]]) -> List[int]:
        ballColor = {} # track color of each ball
        colors = {}    # count how many balls have a color
        
        n = len(queries)
        ans = [0] * n

        for i, (ball, color) in enumerate(queries):
            # if ball already has a color, remove it
            if ball in ballColor:
                c = ballColor[ball]
                colors[c] -= 1
                if colors[c] == 0:
                    del colors[c]

            # set new color
            ballColor[ball] = color
            colors[color] = 1 + colors.get(color, 0);

            # count the distinct colors
            ans[i] = len(colors)

        return ans