public class Solution {
    public int MinDifference(int[] nums) {
        if(nums.Length <= 3) return 0;
        
        var n = nums.Length-1;
        Array.Sort(nums);

        // manually check all 4 combinations
        var minDiff = nums[n]-nums[3];
        minDiff = Math.Min(minDiff, nums[n-1]-nums[2]);
        minDiff = Math.Min(minDiff, nums[n-2]-nums[1]);
        minDiff = Math.Min(minDiff, nums[n-3]-nums[0]);

        return minDiff;
    }
}