class Solution:
    def minimumRecolors(self, blocks: str, k: int) -> int:
        currWhite = 0
        for i in range(k):
            if blocks[i] == 'W': currWhite += 1
        
        minWhite = currWhite
        for right in range(k, len(blocks)):
            if blocks[right - k] == 'W': currWhite -= 1
            if blocks[right] == 'W': currWhite += 1
            minWhite = min(minWhite, currWhite)

        return minWhite