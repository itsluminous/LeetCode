# it is important to note that matrix is already created with all bars
# and you can only remove those bars which are present in hBars and vBars
class Solution:
    def maximizeSquareHoleArea(self, n: int, m: int, hBars: List[int], vBars: List[int]) -> int:
        # adding 1 here because removing 1 bar gives 2 cells, removing 2 gives 3 cells...
        gap = 1 + min(self.getMaxGap(hBars), self.getMaxGap(vBars))
        return gap * gap

    def getMaxGap(self, bars: List[int]) -> int:
        bars.sort()
        ans = curr = 1    # min 1 cell will always be a hole
        for i in range(len(bars)):
            # check if we are able to remove consecutive bars
            if bars[i] == bars[i-1] + 1: curr += 1
            else: curr = 1

            ans = max(ans, curr)
        return ans