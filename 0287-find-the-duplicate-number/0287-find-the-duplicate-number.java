// Floyd's Tortoise and Hare (Cycle Detection). Explaination in my c# code
class Solution {
    public int findDuplicate(int[] nums) {
        if(nums.length <= 1) return -1;
        
        int slow = nums[0], fast = nums[nums[0]];
        while(slow != fast){
            slow = nums[slow];
            fast = nums[nums[fast]];
        }
        
        // now find entry point of duplicate number
        slow = 0;
        while(fast != slow){
            fast = nums[fast];
            slow = nums[slow];
        }
        
        return slow;
    }
}

// Accpeted - O(n) time and O(10^5) space
class SolutionArr {
    public int findDuplicate(int[] nums) {
        var found = new boolean[1_00_001];
        for(var num : nums)
            if(found[num]) return num;
            else found[num] = true;
        
        return -1;
    }
}