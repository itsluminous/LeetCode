class Solution {
    public boolean isArraySpecial(int[] nums) {
        var n = nums.length;
        for(var i=0; i<n-1; i++){
            if((nums[i] & 1) == 1 && (nums[i+1] & 1) == 1) return false;
            if((nums[i] & 1) == 0 && (nums[i+1] & 1) == 0) return false;
        }
        return true;
    }
}