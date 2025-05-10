public class Solution {
    public long MinSum(int[] nums1, int[] nums2) {
        long z1 = 0, s1 = 0; // z1 = count of zeroes in nums1, s1 = sum of nums1
        foreach(var num in nums1){
            s1 += num;
            z1 += num == 0 ? 1 : 0;
        }

        long z2 = 0, s2 = 0; // z2 = count of zeroes in nums2, s2 = sum of nums2
        foreach(var num in nums2){
            s2 += num;
            z2 += num == 0 ? 1 : 0;
        }

        // assume that all zeroes will be replaced with 1 (to keep sum minimum)
        s1 += z1;   
        s2 += z2;

        if(z2 == 0 && s1 > s2) return -1;
        if(z1 == 0 && s2 > s1) return -1;
        return Math.Max(s1, s2);
    }
}