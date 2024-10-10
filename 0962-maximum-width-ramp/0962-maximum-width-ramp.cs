public class Solution {
    public int MaxWidthRamp(int[] nums) {
        var n = nums.Length;

        // populate the rightMax array, which will contain biggest no. on right side
        var rightMax = new int[n];
        rightMax[n-1] = nums[n-1];
        for(var i=n-2; i>=0; i--)
            rightMax[i] = Math.Max(rightMax[i+1], nums[i]);
        
        int left = 0, right = 0, maxWidth = 0;
        while(right < n){
            // move left pointer if needed
            while(left < right && nums[left] > rightMax[right])
                left++;
            maxWidth = Math.Max(maxWidth, right - left);
            right++;
        }

        return maxWidth;
    }
}