public class Solution {
    public int[] ClosestPrimes(int left, int right) {
        int[] ans = [-1, -1];
        if(right <= 2 || left == right) return ans;  // not possible to have 2 primes

        var primeNum = FindPrimes(right + 1);
        var firstPrime = NextPrime(primeNum, left, right);
        if(firstPrime == -1) return ans;

        var diff = right - left + 1; // basically infinity
        while(firstPrime < right) {
            var secondPrime = NextPrime(primeNum, firstPrime + 1, right);
            if(secondPrime == -1) break;  // no other prime exists

            if(secondPrime - firstPrime < diff) {
                diff = secondPrime - firstPrime;
                ans = [firstPrime, secondPrime];
            }

            firstPrime = secondPrime;
        }

        return ans;
    }

    // get next prime by looping through primeNum array
    public int NextPrime(bool[] primeNum, int left, int right) {
        for(var i = left; i <= right; i++) 
            if(primeNum[i]) return i;
        return -1;
    }

    // Sieve Of Eratosthenes
    public bool[] FindPrimes(int n) {
        var isPrime = new bool[n];
        isPrime[2] = true;  // mark 2 as prime
        for(var i = 3; i < n; i += 2)  // mark all odd numbers as prime
            isPrime[i] = true;

        var sqrt = Math.Ceiling(Math.Sqrt(n));
        for(var num = 3; num < sqrt; num += 2) {
            if(!isPrime[num]) continue;
            for(var idx = num * num; idx < n; idx += 2 * num)
                isPrime[idx] = false;
        }

        return isPrime;
    }
}
