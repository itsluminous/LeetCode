class Solution:
    def minOperations(self, nums: List[int], k: int) -> int:
        # find out which bits in k are not matching
        for num in nums: k ^= num
        # return the bits which are not matching
        return k.bit_count()