class Solution {
    public int maxAscendingSum(int[] nums) {
        int maxSum = nums[0], currSum = nums[0];
        
        for(var i=1; i<nums.length; i++){
            if(nums[i] <= nums[i-1]) {
                maxSum = Math.max(maxSum, currSum);
                currSum = nums[i];
            } else {
                currSum += nums[i];
            }
        }
        maxSum = Math.max(maxSum, currSum);
        return maxSum;
    }
}