// simple idea is that (A^B) ^ (A^C) = B^C
// also we need to know count of nums in final array
// because A^A^A = A, but A^A = 0

class Solution {
    public int xorAllNums(int[] nums1, int[] nums2) {
        // find xor of all nums in nums1 & nums2
        int xor1 = 0, xor2 = 0;
        for(var num : nums1) xor1 ^= num;
        for(var num : nums2) xor2 ^= num;

        // return ans based on count in nums1 & nums2
        int count1 = nums1.length, count2 = nums2.length;
        if((count1 & 1) == 0 && (count2 & 1) == 0) return 0;      // both even
        if((count1 & 1) == 1 && (count2 & 1) == 0) return xor2;   // nums1 odd
        if((count1 & 1) == 0 && (count2 & 1) == 1) return xor1;   // nums2 odd
        return xor1 ^ xor2;                                       // both odd
    }
}