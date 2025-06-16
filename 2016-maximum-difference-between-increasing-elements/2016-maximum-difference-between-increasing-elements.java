class Solution {
    public int maximumDifference(int[] nums) {
        int smallest = nums[0], ans = -1;
        for(var i=1; i < nums.length; i++){
            if(nums[i] > smallest)
                ans = Math.max(ans, nums[i] - smallest);
            else 
                smallest = nums[i];
        }

        return ans;
    }
}