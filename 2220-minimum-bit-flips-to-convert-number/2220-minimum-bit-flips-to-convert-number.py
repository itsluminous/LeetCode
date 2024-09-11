class Solution:
    def minBitFlips(self, start: int, goal: int) -> int:
        delta = start ^ goal
        return bin(delta).count('1')