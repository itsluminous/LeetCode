public class Solution {
    public int MaxSubArray(int[] nums) {
        int max = nums[0], curr = nums[0];
        for(var i=1; i<nums.Length; i++){
            curr = Math.Max(curr + nums[i], nums[i]);
            max = Math.Max(max, curr);
        }
        return max;
    }
}