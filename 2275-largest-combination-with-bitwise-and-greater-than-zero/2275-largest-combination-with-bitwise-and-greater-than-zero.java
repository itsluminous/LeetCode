class Solution {
    public int largestCombination(int[] candidates) {
        var bits = new int[24]; // because max value can be 10^7 
        for(var num : candidates){
            for(var i=0; num > 0; i++, num >>= 1)
                if((num & 1) == 1) bits[i]++;
        }

        var largest = 0;
        for(var count : bits)
            largest = Math.max(largest, count);
        
        return largest;
    }
}