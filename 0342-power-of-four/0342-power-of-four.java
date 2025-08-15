// essentially find if number is power of two, but power should be even
// valid ans are : 2^0, 2^2, 2^4, 2^6....
// invalid are : 2^1, 2^3, 2^5, 2^7....

// O(1)
class Solution {
    public boolean isPowerOfFour(int n) {
        if(n < 4) return n == 1;
        if((n & (n-1)) != 0) return false;    // means there are more than one bit set

        // check if even power is set
        // var evenSetBin = "01010101010101010101010101010101";
        // var evenSetNum = Integer.parseInt(evenSetBin, 2);
        // return (n & evenSetNum) != 0;

        // alternate
        // Bitmask: 0x55555555 = 01010101010101010101010101010101
        return (n & 0x55555555) != 0;
    }
}

// Accepted - O(31)
class SolutionElaborate {
    public boolean isPowerOfFour(int n) {
        if(n < 4) return n == 1;
        var oddPos = false;
        var oneBit = 0;
        while(n > 0){
            if((n & 1) == 1){
                oneBit++;
                if(oddPos || oneBit > 1) return false;
            }
            oddPos = !oddPos;
            n >>= 1;
        }
        return true;
    }
}