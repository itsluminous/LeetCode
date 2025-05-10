class Solution:
    def minSum(self, nums1: List[int], nums2: List[int]) -> int:
        z1 = s1 = 0 # z1 = count of zeroes in nums1, s1 = sum of nums1
        for num in nums1:
            s1 += num
            z1 += 1 if num == 0 else 0

        z2 = s2 = 0 # z2 = count of zeroes in nums2, s2 = sum of nums2
        for num in nums2:
            s2 += num
            z2 += 1 if num == 0 else 0

        # assume that all zeroes will be replaced with 1 (to keep sum minimum)
        s1 += z1   
        s2 += z2

        if z2 == 0 and s1 > s2: return -1
        if z1 == 0 and s2 > s1: return -1
        return max(s1, s2)