public class Solution {
    const int MOD = 1_000_000_007;
    long[,] dp;

    public int MinMaxSums(int[] nums, int k) {
        // it's subsequence, order won't matter
        Array.Sort(nums);
        var n = nums.Length;

        // dp to cache C(n,k) i.e. choose k elements from a set of n elements
        dp = new long[n+1, k+1];
        for(var i=0; i<=n; i++)
            for(var j=0; j<=k; j++)
                dp[i,j] = -1;
        
        long sum = 0;
        for(var i=0; i<n; i++){
            var maxSum = (nums[i] * Count(i, k)) % MOD;     // cases where curr num is max in list
            var minSum = (nums[i] * Count(n-i-1, k)) % MOD; // cases where curr num is min in list
            sum = (sum + maxSum + minSum) % MOD;
        }

        return (int)sum;
    }

    // Count is function to choose k elements from a set of n elements
    // Count(n, k) is same as nCk i.e. n!/k!(n-k)!
    // in other words, C(n,k) = C(n−1,k) + C(n−1,k−1)
    private long Count(int n, int k){
        if(k == 1 || n == 0) return 1;  // only one way to pick
        if(dp[n, k] != -1) return dp[n,k];
        return dp[n,k] = (Count(n-1, k) + Count(n-1, k-1)) % MOD;
    }
}

// more on binomial coefficients
// i.e. why C(n,k) = C(n−1,k) + C(n−1,k−1)
// C(n,k) means choosing k elements from a set of n elements
// if I decided to not use n-th element, and pick from remaining ones, it would be C(n-1, k)
// and if I decided that n-th element will be picked for sure, and remaining k-1 will be picked from n-1, then it is C(n-1, k-1)
// hence, choosing k elements from n elements = (k elements from n-1) + (k-1 elements from n-1 elements)
// C(n,k) = C(n−1,k) + C(n−1,k−1)