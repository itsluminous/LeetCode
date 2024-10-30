class Solution {
    public int minimumMountainRemovals(int[] nums) {
        var n = nums.length;
        int[] left = new int[n], right = new int[n];
        Arrays.fill(left,1);    // single number is also LIS
        Arrays.fill(right,1);

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
                maxLen = Math.max(maxLen, left[i] + right[i] - 1);  // -1 because curr no would be counted twice
        }

        return n - maxLen;
    }
}