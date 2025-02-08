class Solution:
    def beautifulSubarrays(self, nums: List[int]) -> int:
        count = 0
        xorFreq = {}
        xorFreq[0] = 1

        xor = 0
        for num in nums:
            xor ^= num
            freq = xorFreq.get(xor, 0)
            count += freq
            xorFreq[xor] = 1 + freq

        return count