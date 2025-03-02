public class Solution {
    long?[,,] dp;

    public int MaxSum(int[] nums, int k, int m) {
        var n = nums.Length;
        dp = new long?[n, k+1, 2];

        // prefix sum of nums array
        var pre = new int[n + 1];
        for(var i = 0; i < n; i++)
            pre[i + 1] = pre[i] + nums[i];

        // start from index 0, picking "k" subarrays. extend = 0 because there is nothing to extend
        return (int)GetMaxSum(nums, pre, m, 0, k, 0);
    }

    // get max sum by picking "k" subarrays starting from index "i"
    private long GetMaxSum(int[] nums, int[] pre, int m, int i, int k, int extend) {
        var n = nums.Length;

        // not enough nums left to pick "k" subarrays of length "m"
        if(n - i < k * m) return int.MinValue;

        // reached end of array
        if(i == n) return k == 0 ? 0 : int.MinValue;

        // check cache
        if(dp[i, k, extend] != null)
            return dp[i, k, extend].Value;

        // option 1: skip the current element and move to the next index
        var ans = GetMaxSum(nums, pre, m, i + 1, k, 0); // extend = 0 because now we have a break in between

        // option 2: extend the previous subarray
        if(extend == 1)
            ans = Math.Max(ans, nums[i] + GetMaxSum(nums, pre, m, i + 1, k, 1));

        // option 3: start new subarray if we still have subarrays left to pick
        if(k > 0 && i + m <= n) {
            var newSum = pre[i + m] - pre[i];
            ans = Math.Max(ans, newSum + GetMaxSum(nums, pre, m, i + m, k - 1, 1));
        }

        dp[i, k, extend] = ans;
        return ans;
    }
}


// TLE (617 / 624 passed)
public class SolutionRecursive {
    (int sum, bool valid)?[,] dp;
    
    public int MaxSum(int[] nums, int k, int m) {
        var n = nums.Length;
        dp = new (int sum, bool valid)?[k+1, n];
        
        var result = MaxSum(nums, k, m, 0);
        return result.valid ? result.sum : 0;
    }

    private (int sum, bool valid) MaxSum(int[] nums, int k, int m, int idx) {
        var n = nums.Length;
        if(k == 0) return (0, true);            // no more subarray needed
        if(idx + m * k > n) return (0, false);  // early exit if not enough numbers left
        if(dp[k, idx] != null) return dp[k, idx].Value;     // return cached value
        
        var maxSum = int.MinValue;
        bool valid = false;
        
        var currSum = 0;
        for(var i = idx; i < idx + m; i++) currSum += nums[i];
        
        for(var i = idx + m - 1; i < n; i++) {
            if(i != idx + m - 1) currSum += nums[i];
            
            var remaining = MaxSum(nums, k - 1, m, i + 1);
            if(!remaining.valid) continue;
            var newSum = currSum + remaining.sum;
            maxSum = Math.Max(maxSum, newSum);
            valid = true;
        }
        
        var skip = MaxSum(nums, k, m, idx + 1);     // skip including curr num
        if(skip.valid && skip.sum > maxSum) {
            maxSum = skip.sum;
            valid = true;
        }
        
        var result = valid ? (maxSum, true) : (0, false);
        dp[k, idx] = result;
        return result;
    }
}