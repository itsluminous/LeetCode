class Solution:
    def largestCombination(self, candidates: List[int]) -> int:
        bits = [0] * 24 # because max value can be 10^7 
        for num in candidates:
            i=0
            while num > 0:
                if (num & 1) == 1: bits[i] += 1
                i += 1
                num >>= 1

        largest = 0
        for count in bits:
            largest = max(largest, count)
        
        return largest