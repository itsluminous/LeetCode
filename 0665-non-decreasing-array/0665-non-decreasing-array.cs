public class Solution {
    public bool CheckPossibility(int[] nums) {
        var modified = false;
        for(var i=1; i<nums.Length; i++){
            if(nums[i-1] <= nums[i]) continue;           // already correct
            if(modified) return false;                   // only one modification allowed
            
            modified = true;
            if(i == 1 || nums[i] >= nums[i-2]) continue; // set prev num = curr num
            nums[i] = nums[i-1];                         // set curr num = prev
        }

        return true;
    }
}