class Solution {
    public int maxSubArray(int[] nums) {
        int maxSum = Integer.MIN_VALUE, currSum = 0;
        for(var num : nums){
            currSum = Math.max(currSum + num, num);
            maxSum = Math.max(maxSum, currSum);
        }
        
        return maxSum;
    }
}