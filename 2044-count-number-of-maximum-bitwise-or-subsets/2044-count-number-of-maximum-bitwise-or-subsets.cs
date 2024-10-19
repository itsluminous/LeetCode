// backtracking
public class Solution {
    int count = 0, target = 0;

    public int CountMaxOrSubsets(int[] nums) {
        foreach(var num in nums) target |= num; // max or possible is OR of all nums
        FindCount(nums, 0, 0);
        return count;
    }

    private void FindCount(int[] nums, int idx, int val){
        if(idx == nums.Length){
            count += val == target ? 1 : 0;
            return;
        }

        // subsets where current num is included
        FindCount(nums, idx+1, val | nums[idx]);
        // subsets where current num is NOT included
        FindCount(nums, idx+1, val);
    }
}