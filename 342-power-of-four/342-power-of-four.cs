public class Solution {
    public bool IsPowerOfFour(int n) {
        if (n < 4) return n == 1;

        // sqrt must be integer
        var sqrt = Math.Sqrt(n);
        if (sqrt % 1 != 0) return false;

        // sqrt must be a power of 2
        var sqrtnum = (int) sqrt;
        return (sqrtnum & (sqrtnum - 1)) == 0; 
    }
}