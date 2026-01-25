public class Solution {
    public int MinimumDifference(int[] nums, int k) {
        Array.Sort(nums);
        var n = nums.Length;
        
        var ans = nums[n-1] - nums[0];
        if(k == n) return ans;
        for(var i=k; i<=n; i++)
            ans = Math.Min(ans, nums[i-1] - nums[i-k]);
        
        return ans;
    }
}