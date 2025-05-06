public class Solution {
    public int[] BuildArray(int[] nums) {
        var n = nums.Length;
        var ans = new int[n];
        for(var i=0; i<n; i++)
            ans[i] = nums[nums[i]];
        return ans;
    }
}