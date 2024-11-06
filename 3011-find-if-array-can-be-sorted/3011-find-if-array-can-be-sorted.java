class Solution {
    public boolean canSortArray(int[] nums) {
        int prevHigh = 0, currLow = nums[0], currHigh = nums[0];
        for(var i=1; i<nums.length; i++){
            // if same segment
            if(Integer.bitCount(nums[i]) == Integer.bitCount(nums[i-1])){
                currLow = Math.min(currLow, nums[i]);
                currHigh = Math.max(currHigh, nums[i]);
            }
            else if(currLow < prevHigh)
                return false;
            else {
                prevHigh = currHigh;
                currHigh = currLow = nums[i];
            }
        }

        return currLow >= prevHigh;
    }
}