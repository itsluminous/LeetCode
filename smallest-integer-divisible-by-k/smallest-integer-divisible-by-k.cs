public class Solution {
    public int SmallestRepunitDivByK(int k) {
        var remainder = 0;
        for(var length=1; length<=k; length++){
            remainder = remainder * 10 + 1;     // so 11 becomes 111
            remainder %= k;                     // this keeps remainder in int range
            if(remainder == 0) return length;   // found number
        }
        return -1;                              // loop is going more than k (not allowed by Pigeonhole Principle)
    }
}