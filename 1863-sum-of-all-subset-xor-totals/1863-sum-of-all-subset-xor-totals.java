// O(N) approach
// if there are N nums, then there are 2^N subsets in total, including empty subset
// every number num is included in exactly half of these subsets
// half of 2^N is 2^N-1
// so any bit that a num sets, needs to be counted 2^N-1 times
// we need not process each num one by one, but can simply OR all the numbers together, to find out all the 1 bits
// if X is OR of all numbers, then answer is X * 2^(N-1) i.e. X << (N-1)
class Solution {
    public int subsetXORSum(int[] nums) {
        var allOr = 0;
        for(var num : nums) allOr |= num;

        return allOr << (nums.length - 1);
    }
}

// Accepted - backtracking
class SolutionBT {
    public int subsetXORSum(int[] nums) {
        return subsetXORSum(nums, 0, 0);
    }

    private int subsetXORSum(int[] nums, int idx, int currXOR) {
        if(idx == nums.length) return currXOR;
        return subsetXORSum(nums, idx+1, currXOR ^ nums[idx]) 
             + subsetXORSum(nums, idx+1, currXOR);
    }
}