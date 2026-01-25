class Solution {
    public int minimumDifference(int[] nums, int k) {
        Arrays.sort(nums);
        var n = nums.length;
        
        var ans = nums[n-1] - nums[0];
        if(k == n) return ans;
        for(var i=k; i<=n; i++)
            ans = Math.min(ans, nums[i-1] - nums[i-k]);
        
        return ans;
    }
}