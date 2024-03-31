class Solution {
    public long countAlternatingSubarrays(int[] nums) {
        long ans = 1;
        int n = nums.length, l = 0;
        
        for(var r=1; r<n; r++){
            if(nums[r] == nums[r-1]) l = r;
            ans += (r-l+1);
        }
        
        return ans;
    }
}