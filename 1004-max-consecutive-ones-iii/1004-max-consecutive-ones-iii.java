public class Solution {
    public int longestOnes(int[] nums, int k) {
        int n = nums.length, l = 0, r = 0;
        for(; r<n; r++){
            if(nums[r] == 0) k--;
            if(k < 0 && nums[l++] == 0) k++;
        }

        return r-l;
    }
}