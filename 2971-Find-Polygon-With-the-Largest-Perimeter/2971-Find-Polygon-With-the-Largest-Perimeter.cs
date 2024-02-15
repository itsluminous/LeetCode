public class Solution {
    public long LargestPerimeter(int[] nums) {
        Array.Sort(nums);
        var n = nums.Length;
        var prefix = new long[n];
        prefix[0] = nums[0];
        for(var i=1; i<n; i++)
            prefix[i] = prefix[i-1] + nums[i];
        
        for(var i=n-1; i>1; i--)
            if(nums[i] < prefix[i-1]) return prefix[i];
        
        return -1;
    }
}