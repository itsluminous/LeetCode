class Solution {
    public int numberOfPairs(int[] nums1, int[] nums2, int k) {
        var good = 0;
        for(var n2 : nums2)
            for(var n1 : nums1)
                if(n1 % (n2 * k) == 0)
                    good++;

        return good;
    }
}