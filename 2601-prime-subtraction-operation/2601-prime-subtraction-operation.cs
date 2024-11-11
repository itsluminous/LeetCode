public class Solution {
    public bool PrimeSubOperation(int[] nums) {
        if(nums.Length == 1) return true;
        var maxVal = nums.Max();
        var isPrime = CheckPrimes(maxVal+1);

        // target is what we want num to become, idx is curr index being processed in nums
        for(int target=1, idx = 0; idx < nums.Length; target++){
            var diff = nums[idx] - target;
            if(diff < 0) return false;  // the num cannot be converted to prime bigger than prev
            if(diff == 0 || isPrime[diff])
                idx++;  // this index is successfully converted
        }
        return true;
    }

    private bool[] CheckPrimes(int n){
        var isPrime = new bool[n];
        for(var i=3; i<n ;i+=2) isPrime[i] = true;  // mark all odd nums as prime
        isPrime[2] = true;  // mark 2 as prime, other even nums will be false

        var sqrt = Math.Ceiling(Math.Sqrt(n));
        for(var i=3; i<sqrt; i+=2){
            if(!isPrime[i]) continue;
            for(var j=i*i; j<n; j+=2*i) 
                isPrime[j] = false;
        }

        return isPrime;
    }
}