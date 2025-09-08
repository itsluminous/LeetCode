public class Solution {
    public int[] GetNoZeroIntegers(int n) {
        int num1 = 0, num2 = 0, mul = 1;
        while(n > 0){
            var digit = n % 10;
            n /= 10;

            // treat 0 & 1 as 10 & 11
            // need to check n>0 to handle case where just carry can fill next digit (eg. n = 19)
            if(digit < 2 && n > 0){
                num1 += mul * 9;
                num2 += mul * (1 + digit);  // same as mul * (10 + digit - 9)
                n--;    // handle carry
            }
            else {
                num1 += mul * 1;
                num2 += mul * (digit - 1);
            }
            mul *= 10;
        }

        return [num1, num2];
    }
}