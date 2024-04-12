# idea is to keep splitting smaller of the two array, till we hit a point where all nums on left of both array are less than all nums on right of both array
class Solution:
    def findMedianSortedArrays(self, nums1: List[int], nums2: List[int]) -> float:
        n1, n2 = len(nums1), len(nums2)
        n, actual_mid = n1 + n2, (n1 + n2 + 1)//2
        if n1 > n2: return self.findMedianSortedArrays(nums2, nums1) # make sure that nums1 is smaller

        l, r = 0, n1
        while l <= r:
            # Split the nums1 array using binary search
            # split nums2 such that actual_mid = n1_split + n2_split
            n1_split = (l+r)//2
            n2_split = actual_mid - n1_split

            # The four numbers just to the left & right of split
            split_left_n1 = nums1[n1_split-1] if n1_split > 0 else float('-inf')
            split_left_n2 = nums2[n2_split-1] if n2_split > 0 else float('-inf')
            split_right_n1 = nums1[n1_split] if n1_split < n1 else float('inf')
            split_right_n2 = nums2[n2_split] if n2_split < n2 else float('inf')

            # if all nums on left are smaller than all nums on right, we found the correct split
            if split_left_n1 <= split_right_n2 and split_left_n2 <= split_right_n1:
                # if odd length, then median is the number on mid of combined array
                if(n%2 == 1): return max(split_left_n1, split_left_n2)

                # for even length, median = (mid1 + mid2) / 2
                mid_sum = max(split_left_n1, split_left_n2) + min(split_right_n1, split_right_n2)
                return mid_sum / 2.0
            elif split_left_n1 > split_right_n2:
                r = n1_split-1
            else:
                l = n1_split+1

        return 0

# Accepted - O(m+n / 2)
class SolutionLinear:
    def findMedianSortedArrays1(self, nums1: List[int], nums2: List[int]) -> float:
        n1, n2 = len(nums1), len(nums2)
        n, median = n1 + n2, (n1 + n2 - 1)/2
        med1 = med2 = 0

        i1 = i2 = 0
        while i1 + i2 <= median:
            if i1 == n1:
                med1 = nums2[i2]
                i2 += 1
            elif i2 == n2:
                med1 = nums1[i1]
                i1 += 1
            elif nums1[i1] < nums2[i2]:
                med1 = nums1[i1]
                i1 += 1
            else:
                med1 = nums2[i2]
                i2 += 1

        if n%2 == 1: med2 = med1
        elif i1 == n1: med2 = nums2[i2]
        elif i2 == n2: med2 = nums1[i1]
        else: med2 = min(nums1[i1], nums2[i2])

        return (med1 + med2)/2.0