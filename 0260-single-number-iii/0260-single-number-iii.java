class Solution {
    public int[] singleNumber(int[] nums) {
        // get the xor value of all numbers
        var allXor = 0;
        for(var num : nums)
            allXor ^= num;
        
        // find any position which has bit set
        // we are choosing the rightmost set bit, but idea is to find any bit which is set
        var setBit = allXor & -allXor;

        // we are sure that out of two numbers, one will have setBit = 0 and other will have setBit = 1
        // so we group all numbers in two categories : those with setBit = 1 and those with setBit = 0
        int numWithSet = 0, numWithoutSet = 0;
        for(var num : nums){
            if((num & setBit) == 0) numWithSet ^= num;
            else numWithoutSet ^= num;
        }

        return new int[]{numWithSet, numWithoutSet};
    }
}