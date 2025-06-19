public class Solution {
    public int PartitionArray(int[] nums, int k) {
        Array.Sort(nums);
        var count = 1;  // 1 = subsequence with all numbers

        var smallest = nums[0];
        foreach(var num in nums){
            if(num - smallest <= k) continue;
            smallest = num;
            count++;    // start new subsequence
        }

        return count;
    }
}