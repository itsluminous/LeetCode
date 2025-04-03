// O(n) - without using extra space
class Solution {
    public long maximumTripletValue(int[] nums) {
        var n = nums.length;
        long ans = 0;

        long largestOnLeft = nums[0];   // nums[i]
        long biggestDiff = 0;           // nums[i] - nums[j]
        for(var k=1; k<n; k++){
            var curr = nums[k];
            ans = Math.max(ans, biggestDiff * curr);                    // (nums[i] - nums[j]) * nums[k]
            biggestDiff = Math.max(biggestDiff, largestOnLeft - curr);  // in case of nums[j] = curr
            largestOnLeft = Math.max(largestOnLeft, curr);              // in case of nums[i] = curr
        }

        return ans;
    }
}

// Accepted - O(n) - using extra array
class SolutionArr {
    public long maximumTripletValue(int[] nums) {
        var n = nums.length;
        long ans = 0;

        // find out largest no. on right of each index
        var largestOnRight = new long[n];
        largestOnRight[n-1] = 0;
        for(var i=n-2; i>=0; i--)
            largestOnRight[i] = Math.max(largestOnRight[i+1], nums[i+1]);

        // find out largest and smallest pair (like #121 : best time to buy & sell stock)
        int largestOnLeft = nums[0];
        for(var i=1; i<n-1; i++){
            var curr = nums[i];
            long val = (largestOnLeft - curr) * largestOnRight[i];

            ans = Math.max(ans, val);
            largestOnLeft = Math.max(largestOnLeft, curr);
        }

        return ans;
    }
}