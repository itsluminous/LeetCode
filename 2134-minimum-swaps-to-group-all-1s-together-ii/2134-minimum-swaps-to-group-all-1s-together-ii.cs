public class Solution {
    public int MinSwaps(int[] nums) {
        // count number of ones
        var totalOnes = nums.Count(x => x == 1);
        
        // base case - no swap needed
        if(totalOnes <= 1) return 0;
        
        // repeat the array twice for circular array
        var nums2 = new int[2*nums.Length];
        for(var i=0; i<nums2.Length; i++)
            nums2[i] = nums[i % nums.Length];
        
        // find window having most ones
        int maxOnesInWindow = 0, onesInCurrWindow = 0;
        for(var i=0; i<nums2.Length; i++){
            if(nums2[i] == 1)
                onesInCurrWindow++;
            if(i >= totalOnes && nums2[i-totalOnes] == 1)   // if number just before window was 1, reduce count
                onesInCurrWindow--;
            maxOnesInWindow = Math.Max(maxOnesInWindow, onesInCurrWindow);
        }
        
        // answer will be number of zeroes in the window with max ones
        return totalOnes - maxOnesInWindow;
    }
}