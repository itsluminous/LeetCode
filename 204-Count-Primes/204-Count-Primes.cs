// Using Sieve Of Eratosthenes
public class Solution {
    public int CountPrimes(int n) {
        if(n <= 2) return 0;
        
        var isPrime = new bool[n];
        for(var i=3; i<n ;i+=2) isPrime[i] = true;  // mark all odd nums as prime
        isPrime[2] = true;  // mark 2 as prime, other even nums will be false

        var sqrt = Math.Ceiling(Math.Sqrt(n));
        for(var i=3; i<sqrt; i+=2){
            if(!isPrime[i]) continue;
            for(var j=i*i; j<n; j+=2*i) 
                isPrime[j] = false;
        }

        var count = 0;
        for (var i = 2; i < n; i++) {
            if (isPrime[i]) count++;
        }

        return count;
    }
}


// Passes - but takes long time
public class SolutionPass {
    public int CountPrimes(int n) {
        if(n < 2) return 0;
        var dp = new int[n+1];
        dp[0] = 0; dp[1] = 0; dp[2] = 1;

        for(var i=3; i<n; i++){
            var isPrime = IsPrime(i);
            dp[i] = isPrime ? 1 + dp[i-1] : dp[i-1];
        }

        return dp[n-1];
    }

    private bool IsPrime(int num){
        if(num == 2) return true;
        if(num < 2 || num % 2 == 0) return false;

        var sqrt = Math.Ceiling(Math.Sqrt(num));
        for(var i=3; i<=sqrt; i+=2)
            if(num % i == 0) return false;

        return true;
    }
}

// Failed - Stack overflow
public class SolutionFailed {
    int[] dp;
    public int CountPrimes(int n) {
        if(n < 2) return 0;
        dp = new int[n+1];
        dp[0] = 0; dp[1] = 0; dp[2] = 1;
        return CountPrimesHelper(n-1);
    }

    public int CountPrimesHelper(int n){
        if(n < 2) return 0;
        if(dp[n] > 0) return dp[n];
        var nIsPrime = IsPrime(n);
        dp[n] = nIsPrime ? 1 + CountPrimesHelper(n-1) : CountPrimesHelper(n-1);
        return dp[n];
    }

    private bool IsPrime(int num){
        if(num == 2) return true;
        if(num < 2 || num % 2 == 0) return false;

        var sqrt = Math.Ceiling(Math.Sqrt(num));
        for(var i=3; i<=sqrt; i+=2)
            if(num % i == 0) return false;

        return true;
    }
}