// explaination : https://leetcode.com/problems/powx-n/solutions/1337794/java-c-simple-o-log-n-easy-faster-than-100-explained/
public class Solution {
    public double MyPow(double x, int n) {
        // convert negative power to positive
        if(n < 0){
            n = -n;
            x = 1/x;
        }

        double ans = 1;
        while(n != 0){
            if ((n&1) == 1) ans *= x;   // when the LSB is 1, then x will be part of ans

            // x^1 = x, x^2 = x * x, x^3 = x * x * x, so on....
            // at every step, x will multiply with itself
            x *= x;     
            n >>>= 1;    // unsigned right shift by 1 (equivalent to divide by 2)
        }

        return ans;
    }
}