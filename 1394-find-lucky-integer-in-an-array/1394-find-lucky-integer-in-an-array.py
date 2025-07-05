class Solution:
    def findLucky(self, arr: List[int]) -> int:
        freq = [0] * 501
        for num in arr: freq[num] += 1
        
        for i in range(500, 0, -1):
            if freq[i] == i: return i
        return -1