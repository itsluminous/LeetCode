public class Solution {
    public int MaxAscendingSum(int[] nums) {
        int maxSum = nums[0], currSum = nums[0];
        
        for(var i=1; i<nums.Length; i++){
            if(nums[i] <= nums[i-1]) {
                maxSum = Math.Max(maxSum, currSum);
                currSum = nums[i];
            } else {
                currSum += nums[i];
            }
        }
        maxSum = Math.Max(maxSum, currSum);
        return maxSum;
    }
}