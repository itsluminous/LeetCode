class Solution {
    public void moveZeroes(int[] nums) {
        int n = nums.length, l = 0;
        for(var r=0; r<n; r++)
            if(nums[r] != 0)
                nums[l++] = nums[r];

        for(; l<n; l++)
            nums[l] = 0;
    }
}