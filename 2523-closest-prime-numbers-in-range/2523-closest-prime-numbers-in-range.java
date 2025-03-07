class Solution {
    public int[] closestPrimes(int left, int right) {
        int[] ans = new int[] {-1, -1};
        if (right <= 2 || left == right) return ans;  // not possible to have 2 primes

        var primeNum = findPrimes(right + 1);
        var firstPrime = nextPrime(primeNum, left, right);
        if(firstPrime == -1) return ans;

        var diff = right - left + 1; // basically infinity
        while(firstPrime < right) {
            var secondPrime = nextPrime(primeNum, firstPrime + 1, right);
            if(secondPrime == -1) break;  // no other prime exists

            if(secondPrime - firstPrime < diff) {
                diff = secondPrime - firstPrime;
                ans[0] = firstPrime;
                ans[1] = secondPrime;
            }

            firstPrime = secondPrime;
        }

        return ans;
    }

    // get next prime by looping through primeNum array
    public int nextPrime(boolean[] primeNum, int left, int right) {
        for (var i = left; i <= right; i++) 
            if (primeNum[i]) return i;
        return -1;
    }

    // Sieve Of Eratosthenes
    public boolean[] findPrimes(int n) {
        boolean[] isPrime = new boolean[n];
        isPrime[2] = true;  // mark 2 as prime
        for (int i = 3; i < n; i += 2)  // mark all odd numbers as prime
            isPrime[i] = true;

        var sqrt = (int)Math.ceil(Math.sqrt(n));
        for(var num = 3; num < sqrt; num += 2) {
            if(!isPrime[num]) continue;
            for(var idx = num * num; idx < n; idx += 2 * num)
                isPrime[idx] = false;
        }

        return isPrime;
    }
}
