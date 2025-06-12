class Solution {
    public int maxAdjacentDistance(int[] nums) {
        var n = nums.length;
        var ans = Math.abs(nums[0] - nums[n-1]);
        for(var i=1; i<n; i++){
            var diff = Math.abs(nums[i] - nums[i-1]);
            ans = Math.max(ans, diff);
        }
        return ans;
    }
}