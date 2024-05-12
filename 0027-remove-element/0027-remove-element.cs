public class Solution {
    public int RemoveElement(int[] nums, int val) {
        int left = 0, right = 0;
        while(right < nums.Length){
            if(nums[right] != val)
                nums[left++] = nums[right];
            right++;
        }
        return left;
    }
}