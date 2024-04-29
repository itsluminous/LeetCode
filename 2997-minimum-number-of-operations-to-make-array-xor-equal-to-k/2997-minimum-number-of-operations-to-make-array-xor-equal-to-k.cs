public class Solution {
    public int MinOperations(int[] nums, int k) {
        // find out which bits in k are not matching
        foreach(var num in nums) k ^= num;
        // return the bits which are not matching
        return BitOperations.PopCount((uint)k);
    }
}

// Accepted - same approach, but verbose
public class SolutionVerbose {
    public int MinOperations(int[] nums, int k) {
        // find out xor value of nums array
        var allxor = nums[0];
        for(var i=1; i<nums.Length; i++)
            allxor ^= nums[i];
        
        // find out which bits are not matching with k
        var remaining = allxor ^ k;
        
        // count the bits which are not matching
        var count = 0;
        while(remaining != 0){
            count += remaining & 1;
            remaining >>= 1;
        }

        return count;
    }
}