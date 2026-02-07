public class Solution {
    public int MinRemoval(int[] nums, int k) {
        Array.Sort(nums);
        var n = nums.Length;
        int r = 0, ans = n-1;

        for(var l=0; l<n; l++){
            while(r < n && nums[r] <= (long)nums[l] * k) r++;
            ans = Math.Min(ans, n - (r-l));
        }

        return ans;
    }
}