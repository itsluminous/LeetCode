class Solution:
    def canBeEqual(self, target: List[int], arr: List[int]) -> bool:
        freq = [0] * 1001
        for num in arr: freq[num] += 1

        for num in target:
            freq[num] -= 1
            if freq[num] == -1: return False
        
        return True