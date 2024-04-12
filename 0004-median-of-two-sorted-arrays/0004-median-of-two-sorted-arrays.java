// idea is to keep splitting smaller of the two array, till we hit a point where all nums on left of both array are less than all nums on right of both array
public class Solution {
    public double findMedianSortedArrays(int[] nums1, int[] nums2) {
        int n1 = nums1.length, n2 = nums2.length, n = n1 + n2, actualMid = (n+1)/2;
        if(n1 > n2) return findMedianSortedArrays(nums2, nums1);    // make sure that nums1 is smaller

        int l = 0, r = n1;
        while(l <= r){
            // Split the nums1 array using binary search
            // split nums2 such that actualMid = n1split + n2split
            var n1split = (l+r)/2;
            var n2split = actualMid - n1split;

            // The four numbers just to the left & right of split
            var splitLeftn1 = n1split > 0 ? nums1[n1split-1] : Integer.MIN_VALUE;
            var splitLeftn2 = n2split > 0 ? nums2[n2split-1] : Integer.MIN_VALUE;
            var splitRightn1 = n1split < n1 ? nums1[n1split] : Integer.MAX_VALUE;
            var splitRightn2 = n2split < n2 ? nums2[n2split] : Integer.MAX_VALUE;

            // if all nums on left are smaller than all nums on right, we found the correct split
            if(splitLeftn1 <= splitRightn2 && splitLeftn2 <= splitRightn1){
                // if odd length, then median is the number on mid of combined array
                if(n%2 == 1) return Math.max(splitLeftn1, splitLeftn2);
                // for even length, median = (mid1 + mid2) / 2
                long midSum = Math.max(splitLeftn1, splitLeftn2) + Math.min(splitRightn1, splitRightn2);
                return midSum / 2.0;
            }
            else if(splitLeftn1 > splitRightn2)
                r = n1split-1;
            else
                l = n1split+1;
        }

        return 0;
    }
}

// Accepted - O(m+n / 2)
class SolutionLinear {
    public double findMedianSortedArrays(int[] nums1, int[] nums2) {
        int n1 = nums1.length, n2 = nums2.length, n = n1 + n2;
        var median = (n-1) / 2;
        int med1 = 0, med2 = 0;

        int i1 = 0, i2 = 0;
        while(i1 + i2 <= median){
            if(i1 == n1)
                med1 = nums2[i2++];
            else if(i2 == n2)
                med1 = nums1[i1++];
            else if(nums1[i1] < nums2[i2])
                med1 = nums1[i1++];
            else
                med1 = nums2[i2++];
        }

        if(n%2 == 1) med2 = med1;
        else if(i1 == n1) med2 = nums2[i2];
        else if(i2 == n2) med2 = nums1[i1];
        else med2 = Math.min(nums1[i1], nums2[i2]);

        return (med1 + med2)/2.0;
    }
}