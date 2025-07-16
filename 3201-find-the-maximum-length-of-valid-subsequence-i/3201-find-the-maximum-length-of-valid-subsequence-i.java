class Solution {
    public int maximumLength(int[] nums) {
        // we can have 3 types of subsequence
        // all odd, all even, alternating parity
        int odd = 0, even = 0, alt = 0;
        var parity = (nums[0] & 1);
        
        for(var num : nums){
            if((num & 1) == 0) even++;
            else odd++;

            if((num & 1) == parity){
                alt++;
                parity = 1 - parity;    // toggle
            }
        }

        return Math.max(alt, Math.max(odd, even));
    }
}