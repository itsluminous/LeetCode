public class Solution {
    public long CountAlternatingSubarrays(int[] nums) {
        long ans = 1;
        int n = nums.Length, l = 0;
        
        for(var r=1; r<n; r++){
            if(nums[r] == nums[r-1]) l = r;
            ans += (r-l+1);
        }
        
        return ans;
    }
}