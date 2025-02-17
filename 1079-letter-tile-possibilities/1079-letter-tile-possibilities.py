class Solution:
    def numTilePossibilities(self, tiles: str) -> int:
        freq = [0] * 26
        for ch in tiles:
            freq[ord(ch) - ord('A')] += 1
        
        return self.countSequences(freq)
    
    def countSequences(self, freq: List[int]) -> int:
        count = 0
        for i in range(26):
            if freq[i] == 0: continue
            count += 1

            # backtrack
            freq[i] -= 1
            count += self.countSequences(freq)
            freq[i] += 1

        return count