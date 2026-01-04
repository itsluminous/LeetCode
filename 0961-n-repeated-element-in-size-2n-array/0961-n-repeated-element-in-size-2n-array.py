class Solution:
    def repeatedNTimes(self, nums: List[int]) -> int:
        freq = [0] * 10001
        for num in nums:
            freq[num] += 1
            if freq[num] == 2: return num
        return -1