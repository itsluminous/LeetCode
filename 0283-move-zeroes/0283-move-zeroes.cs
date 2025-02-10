public class Solution {
    public void MoveZeroes(int[] nums) {
        var start = 0;
        for(var i=0; i<nums.Length; i++){
            if(nums[i] != 0) nums[start++] = nums[i];
        }
        
        for(; start<nums.Length; start++){
            nums[start] = 0;
        }
    }
}