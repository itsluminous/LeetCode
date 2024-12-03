class Solution:
    def addSpaces(self, s: str, spaces: List[int]) -> str:
        sb = []
        idx, maxIdx = 0, len(spaces)
        for i, ch in enumerate(s):            
            if idx < maxIdx and i == spaces[idx]:
                sb.append(" ")
                idx += 1
            sb.append(ch)
        
        return ''.join(sb)