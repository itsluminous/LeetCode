# simple idea is that (A^B) ^ (A^C) = B^C
# also we need to know count of nums in final array
# because A^A^A = A, but A^A = 0

class Solution:
    def xorAllNums(self, nums1: List[int], nums2: List[int]) -> int:
        # find xor of all nums in nums1 & nums2
        xor1 = xor2 = 0
        for num in nums1: xor1 ^= num
        for num in nums2: xor2 ^= num

        # return ans based on count in nums1 & nums2
        count1, count2 = len(nums1), len(nums2)
        if (count1 & 1) == 0 and (count2 & 1) == 0: return 0      # both even
        if (count1 & 1) == 1 and (count2 & 1) == 0: return xor2   # nums1 odd
        if (count1 & 1) == 0 and (count2 & 1) == 1: return xor1   # nums2 odd
        return xor1 ^ xor2                                        # both odd