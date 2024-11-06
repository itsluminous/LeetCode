public class Solution {
    public bool CanSortArray(int[] nums) {
        int prevHigh = 0, currLow = nums[0], currHigh = nums[0];
        for(var i=1; i<nums.Length; i++){
            // if same segment
            if(BitOperations.PopCount((uint)nums[i]) == BitOperations.PopCount((uint)nums[i-1])){
                currLow = Math.Min(currLow, nums[i]);
                currHigh = Math.Max(currHigh, nums[i]);
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