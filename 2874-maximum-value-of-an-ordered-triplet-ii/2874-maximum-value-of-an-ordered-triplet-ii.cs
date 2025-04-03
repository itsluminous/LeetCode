public class Solution {
    public long MaximumTripletValue(int[] nums) {
        var n = nums.Length;
        long ans = 0;

        // find out largest no. on right of each index
        var largestOnRight = new long[n];
        largestOnRight[n-1] = 0;
        for(var i=n-2; i>=0; i--)
            largestOnRight[i] = Math.Max(largestOnRight[i+1], nums[i+1]);

        // find out largest and smallest pair (like #121 : best time to buy & sell stock)
        int largestOnLeft = nums[0];
        for(var i=1; i<n-1; i++){
            var curr = nums[i];
            long val = (largestOnLeft - curr) * largestOnRight[i];

            ans = Math.Max(ans, val);
            largestOnLeft = Math.Max(largestOnLeft, curr);
        }

        return ans;
    }
}