class Solution:
    def minimumPushes(self, word: str) -> int:
        freq = [0] * 26
        for ch in word:
            freq[ord(ch) - ord('a')] += 1
        
        freq.sort()
        count, press = 0, 1

        for i in range(25, -1, -8):
            if freq[i] == 0: break
            for j in range(i, max(-1, i-8), -1):
                count += freq[j] * press
            press += 1
                

        return count