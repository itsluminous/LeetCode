class Solution:
    def largestAltitude(self, gain: List[int]) -> int:
        max_val = curr = 0
        for g in gain:
            curr += g
            max_val = max(max_val, curr)
        return max_val