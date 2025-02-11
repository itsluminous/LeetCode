class Solution {
    public int missingNumber(int[] nums) {
        var n = nums.length;
        var apSum = n*(n+1)/2;
        var numSum = Arrays.stream(nums).sum();
        return apSum - numSum;
    }
}