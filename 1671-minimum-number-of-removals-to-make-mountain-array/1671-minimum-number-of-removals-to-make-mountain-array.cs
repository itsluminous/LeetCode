public class Solution {
    public int MinimumMountainRemovals(int[] nums) {
        var n = nums.Length;
        // single number is also LIS, hence default value of 1
        int[] left = Enumerable.Repeat(1, n).ToArray(), right = Enumerable.Repeat(1, n).ToArray();

        // LIS on left
        for(var i=1; i<n; i++)
            for(var j=0; j<i; j++)
                if(nums[j] < nums[i] && left[i] < left[j]+1)
                    left[i] = left[j]+1;
        
        // LDS on right
        for(var i=n-2; i>=0; i--)
            for(var j=n-1; j>i; j--)
                if(nums[j] < nums[i] && right[i] < right[j]+1)
                    right[i] = right[j]+1;
        
        // identify biggest mountain
        var maxLen = 0;
        for(var i=1; i<n-1; i++){
            if(left[i] > 1 && right[i] > 1)
                maxLen = Math.Max(maxLen, left[i] + right[i] - 1);  // -1 because curr no would be counted twice
        }

        return n - maxLen;
    }
}