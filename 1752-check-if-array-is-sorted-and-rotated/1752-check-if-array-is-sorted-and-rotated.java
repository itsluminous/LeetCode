class Solution {
    public boolean check(int[] nums) {
        var n = nums.length;
        var rotated = false;

        for(var i=1; i<n; i++){
            if(nums[i] >= nums[i-1]) continue;
            if(rotated) return false;
            rotated = true;
        }

        return !rotated || nums[0] >= nums[n-1];
    }
}