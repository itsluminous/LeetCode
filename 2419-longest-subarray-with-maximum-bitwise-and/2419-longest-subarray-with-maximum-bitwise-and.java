class Solution {
    public int longestSubarray(int[] nums) {
        // max AND will always be equal to largest number
        int maxNum = nums[0], prev = nums[0], maxLen = 0, currLen = 0;
        for(var num : nums){
            if(prev != num)
                currLen = 0;    // reset curr counting
            if(num > maxNum){
                maxNum = num;
                maxLen = 0; // reset max counting
            }
            if(num == maxNum){
                currLen++;
                maxLen = Math.max(maxLen, currLen);
            }
            prev = num;
        }

        return maxLen;
    }
}