class Solution:
    def heightChecker(self, heights: List[int]) -> int:
        n = len(heights)

        # count how many students have given height
        freq = [0] * 101
        for h in heights: freq[h] += 1

        # now find misplaced ones
        pos = misplaced = processed = 0
        for h in range(1, 101):
            if processed == n: break
            maxPos = pos + freq[h]
            processed += freq[h]
            for i in range(pos, maxPos):
                if heights[i] != h: misplaced += 1
            pos = maxPos

        return misplaced