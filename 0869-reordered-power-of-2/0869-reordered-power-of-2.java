public class Solution {
    public boolean reorderedPowerOf2(int n) {
        long nFreq = count(n); 
        // now match this freq with all possible powers of 2
        // loop till 29 only because power 30 gives > 10^9 
        for (var i = 0; i < 30; i++) {
            var currCount = count(1 << i);
            if (nFreq == currCount) return true;
        }
        return false;
    }

    // freq of each digit 0-9 in the number
    // since 1 <= N <= 10^9, so up to 8 same digits, hence we can skip using array for counting and use a base10 number
    private long count(int n) {
        long nFreq = 0;
        while (n > 0) {
            nFreq += (long)Math.pow(10, n % 10);
            n /= 10;
        }
        return nFreq;
    }
}

// Accepted - using array for freq counting
class SolutionFreqArr {
    public boolean reorderedPowerOf2(int n) {
        int[] digits = count(n); 
        // now match this freq with all possible powers of 2
        // loop till 29 only because power 30 gives > 10^9 
        for (var i = 0; i < 30; i++) {
            var currCount = count(1 << i);
            if (Arrays.equals(digits, currCount))
                return true;
        }
        return false;
    }

    // freq of each digit 0-9 in the number
    private int[] count(int n) {
        int[] digits = new int[10];
        while (n > 0) {
            digits[n % 10]++;
            n /= 10;
        }
        return digits;
    }
}
