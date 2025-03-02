class Solution {
    Long[][][] dp;

    public int maxSum(int[] nums, int k, int m) {
        var n = nums.length;
        dp = new Long[n][k+1][2];

        // prefix sum of nums array
        var pre = new int[n + 1];
        for(var i = 0; i < n; i++)
            pre[i + 1] = pre[i] + nums[i];

        // start from index 0, picking "k" subarrays. extend = 0 because there is nothing to extend
        return (int)getMaxSum(nums, pre, m, 0, k, 0);
    }

    // get max sum by picking "k" subarrays starting from index "i"
    private long getMaxSum(int[] nums, int[] pre, int m, int i, int k, int extend) {
        var n = nums.length;

        // not enough nums left to pick "k" subarrays of length "m"
        if(n - i < k * m) return Integer.MIN_VALUE;

        // reached end of array
        if(i == n) return k == 0 ? 0 : Integer.MIN_VALUE;

        // check cache
        if(dp[i][k][extend] != null)
            return dp[i][k][extend];

        // option 1: skip the current element and move to the next index
        var ans = getMaxSum(nums, pre, m, i + 1, k, 0); // extend = 0 because now we have a break in between

        // option 2: extend the previous subarray
        if(extend == 1)
            ans = Math.max(ans, nums[i] + getMaxSum(nums, pre, m, i + 1, k, 1));

        // option 3: start new subarray if we still have subarrays left to pick
        if(k > 0 && i + m <= n) {
            var newSum = pre[i + m] - pre[i];
            ans = Math.max(ans, newSum + getMaxSum(nums, pre, m, i + m, k - 1, 1));
        }

        dp[i][k][extend] = ans;
        return ans;
    }
}