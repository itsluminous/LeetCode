// Floyd's Tortoise and Hare (Cycle Detection)
/*
Step 1: Initialize Pointers
First, we initialize two pointers, slow and fast, both set to nums[0]. This is the starting point for both pointers, and it's done to set up the conditions for Floyd's cycle detection algorithm.

Step 2: Detect a Cycle
In this step, we enter a while loop where the slow pointer moves one step at a time (slow = nums[slow]), while the fast pointer moves two steps (fast = nums[nums[fast]]). The loop continues until both pointers meet at some point within the cycle. Note that this meeting point is not necessarily the duplicate number; it's just a point inside the cycle.

Why does this happen? Because there is a duplicate number, there must be a cycle in the 'linked list' created by following nums[i] as next elements. Once a cycle is detected, the algorithm breaks out of this loop.

Step 3: Find the Start of the Cycle (Duplicate Number)
After identifying a meeting point inside the cycle, we reinitialize the slow pointer back to nums[0]. The fast pointer stays at the last meeting point. Now, we enter another while loop where both pointers move one step at a time. The reason behind this is mathematical: according to Floyd's cycle detection algorithm, when both pointers move at the same speed, they will eventually meet at the starting point of the cycle. This is the duplicate number we are looking for.

Step 4: Return the Duplicate Number
Finally, when the slow and fast pointers meet again, the meeting point will be the duplicate number, and we return it as the output.
*/
public class Solution {
    public int FindDuplicate(int[] nums) {
        if(nums.Length <= 1) return -1;
        
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
public class SolutionArr {
    public int FindDuplicate(int[] nums) {
        var found = new bool[1_00_001];
        foreach(var num in nums)
            if(found[num]) return num;
            else found[num] = true;
        
        return -1;
    }
}