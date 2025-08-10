public class Solution {
    public bool ReorderedPowerOf2(int n) {
        var nFreq = Count(n); 
        // now match this freq with all possible powers of 2
        // loop till 29 only because power 30 gives > 10^9 
        for(var i=0; i<30; i++){
            var currCount = Count(1 << i);
            if(nFreq == currCount) return true;
        }
        return false;
    }
    
    // freq of each digit 0-9 in the number
    // since 1 <= N <= 10^9, so up to 8 same digits, hence we can skip using array for counting and use a base10 number
    private long Count(int n){
        long nFreq = 0;
        while(n > 0){
            nFreq += (int)Math.Pow(10, n % 10);
            n /= 10;
        }
        return nFreq;
    }
}

// Accepted - using array for freq counting
public class SolutionFreqArr {
    public bool ReorderedPowerOf2(int n) {
        var digits = Count(n); 
        // now match this freq with all possible powers of 2
        // loop till 29 only because power 30 gives > 10^9 
        for(var i=0; i<30; i++){
            var currCount = Count(1 << i);
            if(digits.SequenceEqual(currCount))
                return true;
        }
        return false;
    }
    
    // freq of each digit 0-9 in the number
    private int[] Count(int n){
        var digits = new int[10];
        while(n > 0){
            digits[n % 10]++;
            n /= 10;
        }
        return digits;
    }
}