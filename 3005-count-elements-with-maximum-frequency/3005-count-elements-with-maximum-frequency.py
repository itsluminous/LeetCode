class Solution:
    def maxFrequencyElements(self, nums: List[int]) -> int:
        maxFreq = maxFreqCount = 0

        freq = [0] * 101
        for num in nums:
            freq[num] += 1
            
            if freq[num] > maxFreq:
                maxFreq = maxFreqCount = freq[num]
            elif freq[num] == maxFreq:
                maxFreqCount += freq[num]

        return maxFreqCount