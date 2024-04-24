public class Solution {
    public int SingleNumber(int[] nums) {
        var val = nums[0];
        for(var i=1; i<nums.Length; i++)
            val ^= nums[i]; //xor
        return val;
    }
}