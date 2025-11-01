class Solution {
    public int[] getSneakyNumbers(int[] nums) {
        var ans = new int[2];
        var ansIdx = 0;

        for(var i=0; i<nums.length; i++){
            var num = nums[i] >= 101 ? nums[i] - 101 : nums[i];
            
            if(nums[num] >= 101)   // visited
                ans[ansIdx++] = num;
            else
                nums[num] += 101;
        }

        return ans;
    }
}