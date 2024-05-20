class Solution {
    public int subsetXORSum(int[] nums) {
        return subsetXORSum(nums, 0, 0);
    }

    private int subsetXORSum(int[] nums, int idx, int currXOR) {
        if(idx == nums.length) return currXOR;
        return subsetXORSum(nums, idx+1, currXOR ^ nums[idx]) 
             + subsetXORSum(nums, idx+1, currXOR);
    }
}