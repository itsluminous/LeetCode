// Floyd's Tortoise and Hare (Cycle Detection)
public class Solution {
    public int FindDuplicate(int[] nums) {
        if(nums.Length <= 1) return -1;
        
        int slow = nums[0], fast = nums[nums[0]];
        while(slow != fast){
            slow = nums[slow];
            fast = nums[nums[fast]];
        }
        
        // now find entry point of duplicate number
        fast = 0;
        while(fast != slow){
            fast = nums[fast];
            slow = nums[slow];
        }
        
        return slow;
    }
}