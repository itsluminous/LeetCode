public class Solution {
    public bool DivideArray(int[] nums) {
        var freq = new int[501];
        foreach(var num in nums)
            freq[num]++;

        // odd freq cannot satisfy conditions
        foreach(var count in freq)
            if((count & 1) == 1) 
                return false;
        
        return true;
    }
}