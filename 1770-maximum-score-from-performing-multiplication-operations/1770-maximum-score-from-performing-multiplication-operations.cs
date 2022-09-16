public class Solution {
    int?[,] dp;
    public int MaximumScore(int[] nums, int[] multipliers) {
        int n = nums.Length, m = multipliers.Length;
        dp = new int?[m,m];
        return Helper(nums, multipliers, 0, n-1, 0);
    }
    
    private int Helper(int[] nums, int[] mult, int nstart, int nend, int midx){
        if(midx == mult.Length) return 0;
        if(dp[midx,nstart] != null) return dp[midx,nstart].Value;
            
        var left = nums[nstart] * mult[midx] + Helper(nums, mult, nstart+1, nend, midx+1);
        var right = nums[nend] * mult[midx] + Helper(nums, mult, nstart, nend-1, midx+1);
        dp[midx,nstart] = Math.Max(left, right);
        
        return dp[midx,nstart].Value;
    }
}