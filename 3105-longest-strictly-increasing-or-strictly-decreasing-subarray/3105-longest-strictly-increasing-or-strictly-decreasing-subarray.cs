public class Solution {
    public int LongestMonotonicSubarray(int[] nums) {
        int inc = 1, dec = 1, maxLen = 1;

        for(var i=1; i<nums.Length; i++){
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
            
            maxLen = Math.Max(maxLen, Math.Max(inc, dec));
        }
        
        return maxLen;
    }
}