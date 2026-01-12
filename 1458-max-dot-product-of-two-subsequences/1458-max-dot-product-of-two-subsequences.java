class Solution {
    int[][] dp;
    final int NEG_INF = (int) -1e9;

    public int maxDotProduct(int[] nums1, int[] nums2) {
        int n1 = nums1.length, n2 = nums2.length;
        dp = new int[n1][n2];   // track what is max dot product starting with given idx in nums1 & nums2
        for(var i=0; i<n1; i++) Arrays.fill(dp[i], Integer.MIN_VALUE);
        
        return maxDotProduct(nums1, nums2, 0, 0);
    }

    private int maxDotProduct(int[] nums1, int[] nums2, int idx1, int idx2) {
        int n1 = nums1.length, n2 = nums2.length;
        if (idx1 == n1 || idx2 == n2) return NEG_INF;
        if (dp[idx1][idx2] != Integer.MIN_VALUE) return dp[idx1][idx2];

        var take = nums1[idx1] * nums2[idx2];

        var ans = Math.max(
            Math.max(
                take + maxDotProduct(nums1, nums2, idx1 + 1, idx2 + 1),     // take both and continue
                take                                                        // take and end here
            ),
            Math.max(
                maxDotProduct(nums1, nums2, idx1 + 1, idx2),                // skip nums1[idx1]
                maxDotProduct(nums1, nums2, idx1, idx2 + 1)                 // skip nums2[idx2]
            )
        );

        return dp[idx1][idx2] = ans;
    }
}