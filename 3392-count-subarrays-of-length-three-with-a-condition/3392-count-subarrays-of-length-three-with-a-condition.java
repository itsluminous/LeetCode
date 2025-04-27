class Solution {
    public int countSubarrays(int[] nums) {
        var count = 0;
        for(int l=0, m=1, r=2; r < nums.length; l++, m++, r++)
            if(nums[m] == 2 * (nums[l] + nums[r]))
                count++;
        return count;
    }
}