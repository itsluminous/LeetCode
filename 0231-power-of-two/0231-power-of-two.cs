// a number is power of 2 if only a single bit is set
public class Solution {
    public bool IsPowerOfTwo(int n) {
        if(n < 2) return n == 1;
        // count number of bits set
        var oneBit = 0;
        while(n > 0){
            if((n & 1) == 1) oneBit++;
            n >>= 1;
        }
        return oneBit < 2;
    }
}

// using shortcut for same logic
public class SolutionShort {
    public bool IsPowerOfTwo(int n) {
        if(n < 2) return n == 1;
        return ((n & n-1) == 0);
    }
}