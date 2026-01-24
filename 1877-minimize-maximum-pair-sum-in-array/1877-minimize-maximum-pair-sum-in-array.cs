public class Solution {
    public int MinPairSum(int[] nums) {
        Array.Sort(nums);
        
        var ans = 0;
        for(int l=0, r=nums.Length-1; l<r; l++, r--)
            ans = Math.Max(ans, nums[l] + nums[r]);
        
        return ans;
    }
}