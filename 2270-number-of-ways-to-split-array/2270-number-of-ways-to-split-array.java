class Solution {
    public int waysToSplitArray(int[] nums) {
        long left = nums[0], right = nums[1];
        int n = nums.length, count = 0;
        for(var i=2; i<n; i++) right += nums[i];

        if(left >= right) count++;
        for(var i=1; i<n-1; i++){
            left += nums[i];
            right -= nums[i];
            if(left >= right) count++;
        }

        return count;
    }
}