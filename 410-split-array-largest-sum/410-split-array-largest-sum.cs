public class Solution {
    public int SplitArray(int[] nums, int m) {
        var n = nums.Length;
        var dp = new int?[n, 50];
        
        var prefixSum = new int[n];
        prefixSum[0] = nums[0];
        for(var i=1; i<n; i++)
            prefixSum[i] = prefixSum[i-1] + nums[i];
        
        if(m == 1)
            return prefixSum[n-1];
        
        return MinMaxSum(nums, 0, m-1, dp, prefixSum);
    }
    
    private int MinMaxSum(int[] nums, int start, int splits, int?[,] dp, int[] prefixSum) {
        var n = nums.Length;
        
        // if we have this in dp
        if(dp[start, splits].HasValue)
            return dp[start, splits].Value;
        
        // if no more splits possible
        if(splits == 0){
            dp[start, splits] = prefixSum[n-1] - prefixSum[start-1];
            return dp[start, splits].Value;
        }
        
        int result = int.MaxValue, currSum = nums[start];
        for(var i=start+1; i<n; i++){
            var val = MinMaxSum(nums, i, splits-1, dp, prefixSum);
            result = Math.Min(result, Math.Max(currSum, val));
            currSum += nums[i];
        }
        
        dp[start, splits] = result;
        return result;
    }
}