class Solution {
    public int[] buildArray(int[] nums) {
        var n = nums.length;
        var ans = new int[n];
        for(var i=0; i<n; i++)
            ans[i] = nums[nums[i]];
        return ans;
    }
}