class Solution:
    def digArtifacts(self, n: int, artifacts: List[List[int]], dig: List[List[int]]) -> int:
        digged = [[False]*n for _ in range(n)]
        for dg in dig:
            digged[dg[0]][dg[1]] = True
        
        extract = 0
        for artifact in artifacts:
            x1,y1,x2,y2 = artifact[0], artifact[1], artifact[2], artifact[3]
            found = True
            for i in range(x1, x2+1):
                for j in range(y1, y2+1):
                    if not digged[i][j]:
                        found = False
                        break
                if not found: break
            
            if found: extract += 1
        
        return extract
                    