public class Solution {
    public int NumberOfPairs(int[] nums1, int[] nums2, int k) {
        var good = 0;
        foreach(var n2 in nums2)
            foreach(var n1 in nums1)
                if(n1 % (n2 * k) == 0)
                    good++;

        return good;
    }
}