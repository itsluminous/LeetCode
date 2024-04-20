class Solution:
    def isRectangleOverlap(self, rec1: List[int], rec2: List[int]) -> bool:
        xOverlap = yOverlap = False
        if rec2[0] > rec1[0] and rec2[0] < rec1[2]: xOverlap = True
        if rec2[2] > rec1[0] and rec2[2] < rec1[2]: xOverlap = True
        if rec1[0] > rec2[0] and rec1[0] < rec2[2]: xOverlap = True
        if rec1[2] > rec2[0] and rec1[2] < rec2[2]: xOverlap = True

        if rec2[1] > rec1[1] and rec2[1] < rec1[3]: yOverlap = True
        if rec2[3] > rec1[1] and rec2[3] < rec1[3]: yOverlap = True
        if rec1[1] > rec2[1] and rec1[1] < rec2[3]: yOverlap = True
        if rec1[3] > rec2[1] and rec1[3] < rec2[3]: yOverlap = True

        return xOverlap and yOverlap