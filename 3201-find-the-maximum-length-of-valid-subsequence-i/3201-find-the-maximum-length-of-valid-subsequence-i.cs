public class Solution {
    public int MaximumLength(int[] nums) {
        // we can have 3 types of subsequence
        // all odd, all even, alternating parity
        int odd = 0, even = 0, alt = 0;
        var parity = (nums[0] & 1);
        
        foreach(var num in nums){
            if((num & 1) == 0) even++;
            else odd++;

            if((num & 1) == parity){
                alt++;
                parity = 1 - parity;    // toggle
            }
        }

        return Math.Max(alt, Math.Max(odd, even));
    }
}