// the trick is that - the max xor value for array will always be 2^maximumBit - 1
// so k will be anything that makes the total xor = 2^maximumBit - 1
public class Solution {
    public int[] GetMaximumXor(int[] nums, int maximumBit) {
        var n = nums.Length;
        int allxor = 0, maxxor = (1 << maximumBit) - 1;
        foreach(var num in nums)
            allxor ^= num;

        var ans = new int[n];
        ans[0] = maxxor ^ allxor;

        for(var i=1; i<n; i++)
            ans[i] = ans[i-1] ^ nums[n-i];

        return ans;
    }
}

// Accepted
public class SolutionSimulation {
    public int[] GetMaximumXor(int[] nums, int maximumBit) {
        int n = nums.Length, allxor = 0;
        foreach(var num in nums)
            allxor ^= num;
        
        var ans = new int[n];
        for(var i=0; i<n; i++){
            int k = 0, mask = 1;
            for(var b=0; b<maximumBit; b++){
                if((allxor & mask) != mask)
                    k |= mask;
                mask <<= 1;
            }
            ans[i] = k;
            allxor ^= nums[n-1-i];
        }

        return ans;
    }
}