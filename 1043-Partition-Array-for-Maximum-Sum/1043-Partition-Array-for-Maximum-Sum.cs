public class Solution {
    int[] dp;
    public int MaxSumAfterPartitioning(int[] arr, int k) {
        var n = arr.Length;
        dp = new int[n];    // for a given index, what is max sum after it
        dp[n-1] = arr[n-1];

        MaxSumAfterPartitioning(arr, k, 0, 1, arr[0]);
        return dp[0];
    }

    private int MaxSumAfterPartitioning(int[] arr, int k, int start, int end, int maxTillNow) {
        if(start >= arr.Length) return -1;
        if(dp[start] > 0) return dp[start];
        if(end == arr.Length) return (maxTillNow * (end-start));

        var excludeEnd = (maxTillNow * (end-start)) + MaxSumAfterPartitioning(arr, k, end, end+1, arr[end]);
        var includeEnd = -1;
        if(end-start < k)
           includeEnd = MaxSumAfterPartitioning(arr, k, start, end+1, Math.Max(maxTillNow, arr[end])); 

        dp[start] = Math.Max(includeEnd, excludeEnd);
        return dp[start];
    }
}