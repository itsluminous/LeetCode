class Solution {
    public int minRemoval(int[] nums, int k) {
        Arrays.sort(nums);
        var n = nums.length;
        int r = 0, ans = n-1;

        for(var l=0; l<n; l++){
            while(r < n && nums[r] <= (long)nums[l] * k) r++;
            ans = Math.min(ans, n - (r-l));
        }

        return ans;
    }
}