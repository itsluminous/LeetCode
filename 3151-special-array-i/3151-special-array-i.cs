public class Solution {
    public bool IsArraySpecial(int[] nums) {
        for(var i=1; i<nums.Length; i++)
            if((nums[i] & 1) == (nums[i-1] & 1))
                return false;
        return true;
    }
}