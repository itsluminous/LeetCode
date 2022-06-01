public class Solution {
    public int[] RunningSum(int[] nums) {
        var n = nums.Length;
        var runningSum = new int[n];
        runningSum[0] = nums[0];
        
        for(var i=1; i<n; i++)
            runningSum[i] = runningSum[i-1] + nums[i];
        
        return runningSum;
    }
}