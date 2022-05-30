// Explaination : https://leetcode.com/problems/divide-two-integers/discuss/13407/C%2B%2B-bit-manipulations
public class Solution {
    public int Divide(int dividend, int divisor) {
        if (dividend == int.MinValue && divisor == -1) return int.MaxValue;
        if (dividend == int.MinValue && divisor == int.MinValue) return 1;
        if (divisor == int.MinValue) return 0;
        
        var ans = 0;
        var sign = (dividend > 0) ^ (divisor > 0) ? -1 : 1;     // check sign of output
        // handle dividend = -2147483648, because positive max is 2147483647 only
        if (dividend == int.MinValue)
        {
            if (divisor < 0) dividend -= divisor;
            else dividend += divisor;
            ans++;
        }
        // change dividend and divisor to positive, and long type for bit operations
        long dvd = Math.Abs(dividend),  dvs = Math.Abs(divisor);
        
        while(dvd >= dvs){
            long temp = dvs, mul = 1;
            while (temp << 1 <= dvd) {
                temp <<= 1;
                mul <<= 1;
            }
            dvd -= temp;
            ans += (int)mul;
        }
        
        return sign * ans;
    }
}