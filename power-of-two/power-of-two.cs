public class Solution {
    public bool IsPowerOfTwo(int n) {
        if(n < 2) return n == 1;
        // Power of 2 means only one bit of n is '1', so use the trick n&(n-1)==0 to test
        return ((n & n-1) == 0);
    }
}