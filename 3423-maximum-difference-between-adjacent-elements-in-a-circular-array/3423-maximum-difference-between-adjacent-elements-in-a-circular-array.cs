public class Solution {
    public int MaxAdjacentDistance(int[] nums) {
        var n = nums.Length;
        var ans = Math.Abs(nums[0] - nums[n-1]);
        for(var i=1; i<n; i++){
            var diff = Math.Abs(nums[i] - nums[i-1]);
            ans = Math.Max(ans, diff);
        }
        return ans;
    }
}