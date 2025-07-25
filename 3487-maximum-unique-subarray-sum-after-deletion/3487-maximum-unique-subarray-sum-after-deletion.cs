public class Solution {
    public int MaxSum(int[] nums) {
        Array.Sort(nums);
        if(nums[^1] < 0) return nums[^1]; // if only negative numbers

        int total = 0, prev = 0;
        foreach(var num in nums){
            if(num < 0 || num == prev) continue;
            total += num;
            prev = num;
        }

        return total;
    }
}