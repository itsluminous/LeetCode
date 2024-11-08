class Solution {
    public int[] getMaximumXor(int[] nums, int maximumBit) {
        int n = nums.length, allxor = nums[0];
        for(var i=1; i<nums.length; i++)
            allxor ^= nums[i];
        
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