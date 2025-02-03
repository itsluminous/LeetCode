class Solution {
    public int longestMonotonicSubarray(int[] nums) {
        int inc = 1, dec = 1, maxLen = 1;

        for(var i=1; i<nums.length; i++){
            if(nums[i] > nums[i-1]){
                inc++;
                dec = 1;
            }
            else if(nums[i] < nums[i-1]){
                dec++;
                inc = 1;
            }
            else
                inc = dec = 1;
            
            maxLen = Math.max(maxLen, Math.max(inc, dec));
        }
        
        return maxLen;
    }
}