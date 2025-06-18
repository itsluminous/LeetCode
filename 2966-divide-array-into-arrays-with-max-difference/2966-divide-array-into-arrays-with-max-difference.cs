public class Solution {
    public int[][] DivideArray(int[] nums, int k) {
        Array.Sort(nums);
        
        var n = nums.Length;
        var ansLen = n/3;
        var ans = new int[ansLen][];

        for(var i=0; i<ansLen; i++){
            var idx = i * 3;
            if(nums[idx+2] - nums[idx] > k) return new int[0][];
            ans[i] = [nums[idx], nums[idx+1], nums[idx+2]];
        }

        return ans;
    }
}