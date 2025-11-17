class Solution {
    public boolean kLengthApart(int[] nums, int k) {
        var prev = -k;
        for(var i=0; i<nums.length; i++){
            if(nums[i] == 0) continue;
            if(i - prev < k) return false;
            prev = i+1;
        }
        return true;
    }
}