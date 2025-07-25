class Solution {
    public int maxSum(int[] nums) {
        Arrays.sort(nums);
        if(nums[nums.length - 1] < 0) return nums[nums.length - 1]; // if only negative numbers

        int total = 0, prev = 0;
        for(var num : nums){
            if(num < 0 || num == prev) continue;
            total += num;
            prev = num;
        }

        return total;
    }
}