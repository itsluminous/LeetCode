// 10^6 = 11110100001001000000
// so we can have max 19 bits set
// prime numbers in this range are : 2, 3, 5, 7, 11, 13, 17, 19

public class Solution {
    public int CountPrimeSetBits(int left, int right) {
        var primes = new HashSet<int>{2, 3, 5, 7, 11, 13, 17, 19};
        var ans = 0;
        for(var num = left; num <= right; num++) {
            var bits = 0;
            for(var n = num; n > 0; n >>= 1) bits += n & 1;
            ans += primes.Contains(bits) ? 1 : 0;
        }
        return ans;  
    }
}