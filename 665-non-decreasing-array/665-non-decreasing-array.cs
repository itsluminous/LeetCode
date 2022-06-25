public class Solution {
    public bool CheckPossibility(int[] nums) {
        int n = nums.Length, count = 0;
        for(var i=1; i<n && count <= 1; i++){
            if(nums[i-1] > nums[i]){
                count++;
                // if nums[i-1] looks out of sync, then update that, else nums[i] to avoid 2 updates
                if(i-2 < 0 || nums[i-2] <= nums[i])  nums[i-1] = nums[i];
                else nums[i] = nums[i-1];
            }
        }
        return count <= 1;
    }
}