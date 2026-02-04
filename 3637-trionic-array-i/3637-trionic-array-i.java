// we just count how many slopes are present in array. it should be 3
class Solution {
    public boolean isTrionic(int[] nums) {
        int n = nums.length, count = 1;
        if(nums[0] >= nums[1]) return false;

        for(var i = 2; i < n; i++) {
            if(nums[i - 1] == nums[i]) return false;
            // if slope changes then increment count
            if((nums[i - 2] - nums[i - 1]) * (nums[i - 1] - nums[i]) < 0) count++;
        }
        return count == 3;
    }
}