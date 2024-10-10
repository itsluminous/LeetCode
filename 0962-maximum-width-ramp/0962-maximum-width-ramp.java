class Solution {
    public int maxWidthRamp(int[] nums) {
        var n = nums.length;

        // populate the rightMax array, which will contain biggest no. on right side
        var rightMax = new int[n];
        rightMax[n-1] = nums[n-1];
        for(var i=n-2; i>=0; i--)
            rightMax[i] = Math.max(rightMax[i+1], nums[i]);
        
        int left = 0, right = 0, maxWidth = 0;
        while(right < n){
            // move left pointer if needed
            while(left < right && nums[left] > rightMax[right])
                left++;
            maxWidth = Math.max(maxWidth, right - left);
            right++;
        }

        return maxWidth;
    }
}