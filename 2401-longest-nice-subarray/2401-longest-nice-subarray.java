class Solution {
    public int longestNiceSubarray(int[] nums) {
        int longest = 0, mask = 0;

        for(int left = 0, right = 0; right < nums.length; right++){
            // while even a single bit was already set, shift left window
            while((mask & nums[right]) != 0)
                mask ^= nums[left++];
            
            mask |= nums[right];    // set bits from curr number in mask
            longest = Math.max(longest, right - left + 1);
        }

        return longest;
    }
}

// Accepted - original soln, one extra step
class SolutionOrig {
    public int longestNiceSubarray(int[] nums) {
        int longest = 0, mask = 0;

        for(int left = 0, right = 0; right < nums.length; right++){
            var curr = mask ^ nums[right];

            // while even a single bit was already set, shift left window
            while((curr & mask) != mask){
                mask ^= nums[left++];
                curr = mask ^ nums[right];
            }
            longest = Math.max(longest, right - left + 1);
            mask ^= nums[right];    // set bits from curr number in mask
        }

        return longest;
    }
}