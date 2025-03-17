class Solution {
    public boolean divideArray(int[] nums) {
        var freq = new int[501];
        for(var num : nums)
            freq[num]++;

        // odd freq cannot satisfy conditions
        for(var count : freq)
            if((count & 1) == 1) 
                return false;
        
        return true;
    }
}