public class Solution {
    public int SubsetXORSum(int[] nums, int idx = 0, int currXOR = 0) {
        if(idx == nums.Length) return currXOR;
        return SubsetXORSum(nums, idx+1, currXOR ^ nums[idx]) 
             + SubsetXORSum(nums, idx+1, currXOR);
    }
}