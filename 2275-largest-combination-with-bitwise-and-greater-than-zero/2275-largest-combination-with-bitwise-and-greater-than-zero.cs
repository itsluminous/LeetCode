public class Solution {
    public int LargestCombination(int[] candidates) {
        var bits = new int[24]; // because max value can be 10^7 
        foreach(var num in candidates){
            var n = num;
            for(var i=0; n > 0; i++, n >>= 1)
                if((n & 1) == 1) bits[i]++;
        }

        var largest = 0;
        foreach(var count in bits)
            largest = Math.Max(largest, count);
        
        return largest;
    }
}