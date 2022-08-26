public class Solution {
    public bool ReorderedPowerOf2(int n) {
        var digits = Count(n); 
        for(var i=0; i<30; i++){            // loop till 29 only because power 30 gives > 10^9 
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