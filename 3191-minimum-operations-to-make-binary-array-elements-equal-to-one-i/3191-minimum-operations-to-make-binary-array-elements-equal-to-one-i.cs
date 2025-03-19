public class Solution {
    public int MinOperations(int[] nums) {
        var flips = 0;

        for(var i=0; i < nums.Length-2; i++){
            if(nums[i] == 1) continue;
            
            flips++;
            nums[i+1] ^= 1;     // flip next number
            nums[i+2] ^= 1;     // flip next to next number
        }

        if(nums[^1] == 0 || nums[^2] == 0) return -1;   // failure, if there are pending flips 
        return flips;
    }
}