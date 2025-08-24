public class Solution {
    public int LongestSubarray(int[] nums) {
        int l = 0, maxLen = 0, zero = 0;
        for(var r=0; r<nums.Length; r++){
            zero += 1-nums[r];  // if curr nums[r] == 0, increment count
            while(zero > 1)
                zero -= 1 - nums[l++];
            maxLen = Math.Max(maxLen, r-l);
        }
        return maxLen;
    }
}