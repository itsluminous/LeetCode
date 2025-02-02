public class Solution {
    public bool Check(int[] nums) {
        var n = nums.Length;
        var rotated = false;

        for(var i=1; i<n; i++){
            if(nums[i] >= nums[i-1]) continue;
            if(rotated) return false;
            rotated = true;
        }

        if(!rotated || nums[0] >= nums[n-1]) return true;
        return false;
    }
}