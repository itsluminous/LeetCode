class Solution:
    def minimumCost(self, m: int, n: int, hCut: List[int], vCut: List[int]) -> int:
        hCut.sort()
        vCut.sort()

        hidx, vidx = len(hCut)-1,len(vCut)-1
        hCount = vCount = 1
        cost = 0
        
        while hidx >= 0 and vidx >= 0:
            if hCut[hidx] >= vCut[vidx]:
                cost += (hCut[hidx] * vCount)
                hCount += 1
                hidx -= 1
            else:
                cost += (vCut[vidx] * hCount)
                vCount += 1
                vidx -= 1
        
        for i in range(hidx, -1, -1):
            cost += hCut[i] * vCount
        
        for i in range(vidx, -1, -1):
            cost += vCut[i] * hCount

        return cost