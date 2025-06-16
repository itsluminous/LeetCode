public class Solution {
    public int MaximumDifference(int[] nums) {
        int smallest = nums[0], ans = -1;
        for(var i=1; i < nums.Length; i++){
            if(nums[i] > smallest)
                ans = Math.Max(ans, nums[i] - smallest);
            else 
                smallest = nums[i];
        }

        return ans;
    }
}