class Solution {
    public int minDifference(int[] nums) {
        if(nums.length <= 3) return 0;
        
        var n = nums.length-1;
        Arrays.sort(nums);

        // manually check all 4 combinations
        var minDiff = nums[n]-nums[3];
        minDiff = Math.min(minDiff, nums[n-1]-nums[2]);
        minDiff = Math.min(minDiff, nums[n-2]-nums[1]);
        minDiff = Math.min(minDiff, nums[n-3]-nums[0]);

        return minDiff;
    }
}