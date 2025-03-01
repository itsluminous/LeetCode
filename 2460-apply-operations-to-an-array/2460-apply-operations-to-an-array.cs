public class Solution {
    public int[] ApplyOperations(int[] nums) {
        var n = nums.Length;
        int left = 0, right = 0;

        while(right < n-1){
            if(nums[right] != nums[right+1] && nums[right] != 0)
                nums[left++] = nums[right];
            else if(nums[right] == nums[right+1] && nums[right] == 0)
                right++;
            else if(nums[right] == nums[right+1])
                nums[left++] = 2 * nums[right++];

            right++;
        }

        if(right < n)
            nums[left++] = nums[right]; // explicit operation for last digit
        
        // append 0
        while(left < n) nums[left++] = 0;
        return nums;
    }
}