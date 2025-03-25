class Solution:
    def checkValidCuts(self, n: int, rectangles: List[List[int]]) -> bool:
        return self.canCut(rectangles, 0) or self.canCut(rectangles, 1)

    def canCut(self, rectangles: List[List[int]], idx: int) -> bool:
        rectangles.sort(key=lambda r : r[idx])
        cuts = 0
        prevEnd = rectangles[0][idx+2]

        for rect in rectangles:
            start, end = rect[idx], rect[idx+2]
            if start >= prevEnd:
                cuts += 1
                if cuts == 2: return True
            prevEnd = max(prevEnd, end)

        return False