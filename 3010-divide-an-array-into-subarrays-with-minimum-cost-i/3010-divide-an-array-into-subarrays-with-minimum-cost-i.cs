public class Solution {
    public int MinimumCost(int[] nums) {
        int small1 = 51, small2 = 51;

        for(var i=1; i<nums.Length; i++){
            if(nums[i] <= small1){
                small2 = small1;
                small1 = nums[i];
            }
            else if(nums[i] < small2)
                small2 = nums[i];
        }

        return nums[0] + small1 + small2;
    }
}