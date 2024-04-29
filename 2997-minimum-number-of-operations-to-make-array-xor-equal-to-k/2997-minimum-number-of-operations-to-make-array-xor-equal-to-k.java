public class Solution {
    public int minOperations(int[] nums, int k) {
        // find out which bits in k are not matching
        for(var num : nums) k ^= num;
        // return the bits which are not matching
        return Integer.bitCount(k);
    }
}