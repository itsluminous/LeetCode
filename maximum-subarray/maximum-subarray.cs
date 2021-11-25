public class Solution {
    public int MaxSubArray(int[] nums) {
        int max = nums[0], curr = nums[0];
        for(int i=1; i<nums.Length; i++){
            curr = Math.Max(nums[i], curr+nums[i]);
            max = Math.Max(max, curr);
        }
        
        return max;
    }
}