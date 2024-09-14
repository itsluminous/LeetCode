class Solution {
    public int longestSubarray(int[] nums) {
        int prev = 0, currCount = 0, maxCount = 0, maxVal = 0;
        for(var i=0; i<nums.length; i++){
            if(nums[i] > maxVal){
                currCount = maxCount = 1;
                maxVal = nums[i];
            }
            if(nums[i] == maxVal){
                if(prev != maxVal)
                    currCount = 1;
                else{
                    currCount++;
                    maxCount = Math.max(maxCount, currCount);
                }
            }
            prev = nums[i];
        }

        return maxCount;
    }
}