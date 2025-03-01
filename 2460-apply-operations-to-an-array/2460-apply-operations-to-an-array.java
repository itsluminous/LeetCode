class Solution {
    public int[] applyOperations(int[] nums) {
        int n = nums.length, left = 0, right;

        for(right = 0; right < n-1; right++){
            if(nums[right] != nums[right+1] && nums[right] != 0)
                nums[left++] = nums[right];
            else if(nums[right] == nums[right+1] && nums[right] != 0)
                nums[left++] = 2 * nums[right++];
            else if(nums[right] == nums[right+1])   // and nums[right] == 0
                right++;
        }

        // explicit operation for last digit
        if(right < n) nums[left++] = nums[right]; 
        
        // append 0 at end and return
        while(left < n) nums[left++] = 0;
        return nums;
    }
}