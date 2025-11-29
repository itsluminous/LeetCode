class Solution {
    public int minOperations(int[] nums, int k) {
        var sum = 0;
        for(var num : nums) sum += num;
        return sum % k;
    }
}