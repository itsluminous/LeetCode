public class Solution {
    public bool KLengthApart(int[] nums, int k) {
        var prev = -k;
        for(var i=0; i<nums.Length; i++){
            if(nums[i] == 0) continue;
            if(i - prev < k) return false;
            prev = i+1;
        }
        return true;
    }
}