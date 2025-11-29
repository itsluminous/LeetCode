public class Solution {
    public int MinOperations(int[] nums, int k) {
        var sum = nums.Sum();
        return sum % k;
    }
}