// Let x be 38 (100110), and n be 37.
// smallest no. in array will always be x (because all bits in x need to be 1)
// so we need remaining 37 - 1 = 36 (100100) additional elements.
// we need to fit these 100100 of 36 in the 0's of 38 (000100110)
// 36    1 0 0   1 0     0
// 38    0 0 0 1 0 0 1 1 0
// ans   1 0 0 1 1 0 1 1 0
class Solution {
    public long minEnd(int n, int x) {
        long num = x, remaining = n-1, pos = 1;
        for(remaining = n-1; remaining > 0; pos <<= 1){
            if((pos & x) > 0) continue;     // the bit at this pos is 1 in x, skip it
            num |= pos * (remaining & 1);   // set num's bit at pos position if last bit of remaining is 1
            remaining >>= 1;                // right shift remaining, so that we try next pos now
        }

        return num;
    }
}

// O(n) - accepted in java & c#
// smallest no. in array will always be x
// so we start from x and keep incrementing till count is n
// in every increment, ensure that at least same bits as x are set
class SolutionLinear {
    public long minEnd(int n, int x) {
        long num = x;
        for(var i=1; i<n; i++){
            num++;      // increment num
            num |= x;   // ensure that at least the bits in x are set
        }

        return num;
    }
}