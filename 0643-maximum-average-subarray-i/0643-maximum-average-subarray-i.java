public class Solution {
    public double findMaxAverage(int[] nums, int k) {
        double sum = 0, maxSum = 0;
        for(var i=0; i<k; i++) sum += nums[i];
        maxSum = sum;

        var l = 0;
        for(var r=k; r<nums.length; r++, l++){
            sum += nums[r] - nums[l];
            maxSum = Math.max(maxSum, sum);
        }

        return maxSum/k;
    }
}