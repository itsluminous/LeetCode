// 10^6 = 11110100001001000000
// so we can have max 19 bits set
// prime numbers in this range are : 2, 3, 5, 7, 11, 13, 17, 19

class Solution {
    public int countPrimeSetBits(int left, int right) {
        Set<Integer> primes = new HashSet<>(Arrays.asList(2, 3, 5, 7, 11, 13, 17, 19));
        var ans = 0;
        for(var num = left; num <= right; num++) {
            var bits = Integer.bitCount(num);
            ans += primes.contains(bits) ? 1 : 0;
        }
        return ans;  
    }
}