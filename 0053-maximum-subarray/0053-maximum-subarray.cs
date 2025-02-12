public class Solution {
    public int MaxSubArray(int[] nums) {
        int maxSum = int.MinValue, currSum = 0;
        foreach(var num in nums){
            currSum = Math.Max(currSum + num, num);
            maxSum = Math.Max(maxSum, currSum);
        }
        
        return maxSum;
    }
}