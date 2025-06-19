class Solution {
    public int partitionArray(int[] nums, int k) {
        Arrays.sort(nums);
        var count = 1;  // 1 = subsequence with all numbers

        var smallest = nums[0];
        for(var num : nums){
            if(num - smallest <= k) continue;
            smallest = num;
            count++;    // start new subsequence
        }

        return count;
    }
}