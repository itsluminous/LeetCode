public class Solution {
    public int longestSubarray(int[] nums) {
        int n = nums.length, k = 1, l = 0, r = 0, z = 0, max = 0;
        for(; r<n; r++){
            if(nums[r] == 1) continue;
            if(nums[r] == 0 && z < k){
                z++;
                continue;
            }

            // if nums[r] == 0 && z == k
            max = Math.max(max, r-l-k);
            if(nums[l] == 0 && z != 0) z--;
            l++; 
            if(r >= l) r--;
        }

        return Math.max(max, (r-l-k));
    }
}