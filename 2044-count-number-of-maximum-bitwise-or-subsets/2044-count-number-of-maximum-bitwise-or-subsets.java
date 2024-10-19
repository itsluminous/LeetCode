// backtracking
class Solution {
    int count = 0, target = 0;

    public int countMaxOrSubsets(int[] nums) {
        for(var num : nums) target |= num; // max or possible is OR of all nums
        findCount(nums, 0, 0);
        return count;
    }

    private void findCount(int[] nums, int idx, int val){
        if(idx == nums.length){
            count += val == target ? 1 : 0;
            return;
        }

        // subsets where current num is included
        findCount(nums, idx+1, val | nums[idx]);
        // subsets where current num is NOT included
        findCount(nums, idx+1, val);
    }
}