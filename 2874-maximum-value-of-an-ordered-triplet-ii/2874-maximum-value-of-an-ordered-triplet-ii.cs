// O(n) - without using extra space
public class Solution {
    public long MaximumTripletValue(int[] nums) {
        var n = nums.Length;
        long ans = 0;

        long largestOnLeft = nums[0];   // nums[i]
        long biggestDiff = 0;           // nums[i] - nums[j]
        for(var k=1; k<n; k++){
            var curr = nums[k];
            ans = Math.Max(ans, biggestDiff * curr);                    // (nums[i] - nums[j]) * nums[k]
            biggestDiff = Math.Max(biggestDiff, largestOnLeft - curr);  // in case of nums[j] = curr
            largestOnLeft = Math.Max(largestOnLeft, curr);              // in case of nums[i] = curr
        }

        return ans;
    }
}

// Accepted - O(n) - using extra array
public class SolutionArr {
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