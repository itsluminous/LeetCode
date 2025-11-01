public class Solution {
    public int[] GetSneakyNumbers(int[] nums) {
        var ans = new int[2];
        var ansIdx = 0;

        for(var i=0; i<nums.Length; i++){
            var num = nums[i] >= 101 ? nums[i] - 101 : nums[i];
            
            if(nums[num] >= 101)   // visited
                ans[ansIdx++] = num;
            else
                nums[num] += 101;
        }

        return ans;
    }
}