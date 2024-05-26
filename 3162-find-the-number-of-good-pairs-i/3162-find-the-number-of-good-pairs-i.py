class Solution:
    def numberOfPairs(self, nums1: List[int], nums2: List[int], k: int) -> int:
        good = 0
        for n2 in nums2:
            for n1 in nums1:
                if n1 % (n2 * k) == 0:
                    good += 1

        return good