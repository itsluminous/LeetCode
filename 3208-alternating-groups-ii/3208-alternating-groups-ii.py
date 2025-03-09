class Solution:
    def numberOfAlternatingGroups(self, colors: List[int], k: int) -> int:
        n, ans, same = len(colors), 0, 0

        # count same adjacent colors in first k tiles
        for i in range(1, k):
            if colors[i] == colors[i-1]: same += 1
        if same == 0: ans += 1

        # track same adjacent colors for each k window
        lPrev, rPrev = colors[0], colors[k-1]
        for l in range(1, n):
            r = (l+k-1)%n
            if colors[l] == lPrev: same -= 1
            if colors[r] == rPrev: same += 1
            if same == 0: ans += 1

            lPrev = colors[l]
            rPrev = colors[r]

        return ans