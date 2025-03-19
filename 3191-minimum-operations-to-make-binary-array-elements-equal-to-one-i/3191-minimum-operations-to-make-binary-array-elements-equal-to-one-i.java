class Solution {
    public int minOperations(int[] nums) {
        int flips = 0, n = nums.length;

        for(var i=0; i<n-2; i++){
            if(nums[i] == 1) continue;
            
            flips++;
            nums[i+1] ^= 1;     // flip next number
            nums[i+2] ^= 1;     // flip next to next number
        }

        if(nums[n-1] == 0 || nums[n-2] == 0) return -1;   // failure, if there are pending flips 
        return flips;
    }
}