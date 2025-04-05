// O(N) approach
// if there are N nums, then there are 2^N subsets in total, including empty subset
// every number num is included in exactly half of these subsets
// half of 2^N is 2^N-1
// so any bit that a num sets, needs to be counted 2^N-1 times
// we need not process each num one by one, but can simply OR all the numbers together, to find out all the 1 bits
// if X is OR of all numbers, then answer is X * 2^(N-1) i.e. X << (N-1)
public class Solution {
    public int SubsetXORSum(int[] nums) {
        var allOr = 0;
        foreach(var num in nums) allOr |= num;
        
        return allOr << (nums.Length - 1);
    }
}

// Accepted - backtracking
public class SolutionBT {
    public int SubsetXORSum(int[] nums, int idx = 0, int currXOR = 0) {
        if(idx == nums.Length) return currXOR;
        return SubsetXORSum(nums, idx+1, currXOR ^ nums[idx]) 
             + SubsetXORSum(nums, idx+1, currXOR);
    }
}