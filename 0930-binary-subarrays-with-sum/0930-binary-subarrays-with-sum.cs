// NumSubarraysWithSum(10) = NumSubarraysWithAtMost(10) - NumSubarraysWithAtMost(9)
// This is because -
// NumSubarraysWithAtMost(10) will give us numbers which match goal, goal-1 , goal-2 , goal-3...
// NumSubarraysWithAtMost(9) will give us numbers which match  goal-1 , goal-2 , goal-3...
// if we subtract, we are left with only those numbers which match goal

public class Solution {
    public int NumSubarraysWithSum(int[] nums, int goal) {
        return AtMost(nums, goal) - AtMost(nums, goal-1);
    }

    private int AtMost(int[] nums, int goal){
        if(goal < 0) return 0;
        int n = nums.Length, left = 0, count = 0, sum = 0;
        for(var right = 0; right<n; right++){
            sum += nums[right];
            while(sum > goal){
                sum -= nums[left];
                left++;
            }
            count += (right - left + 1);
        }
        return count;
    }
}