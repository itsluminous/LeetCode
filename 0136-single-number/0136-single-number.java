public class Solution {
    public int singleNumber(int[] nums) {
        var val = nums[0];
        for(var i=1; i<nums.length; i++)
            val ^= nums[i]; //xor
        return val;
    }
}