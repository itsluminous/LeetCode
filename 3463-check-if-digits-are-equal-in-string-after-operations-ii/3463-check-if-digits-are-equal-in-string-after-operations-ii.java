// if original string has digits d0, d1, d2, ..., d_{n-1}, where n is the initial length.
// After the first step, the new digits are (d0 + d1) mod 10, (d1 +d2) mod 10, ..., (d_{n-2}+d_{n-1}) mod 10. So the new string has length n-1.
// Then next step: ((d0+d1) + (d1+d2))%10, ((d1+d2)+(d2+d3))%10. 
//      Which simplifies to (d0 + 2d1 + d2) %10, (d1 + 2d2 + d3) %10
// Next step: ( (d0 + 2d1 +d2) + (d1 + 2d2 +d3) ) %10 → (d0 +3d1 +3d2 +d3) %10
// Basically, we form a Pascal's triangal where a coefficient is applied on each digit at each level

// For Original digits: 3,9,0,2
// Step 1: 12 mod10=2, 9, 2 → 2,9,2
// Step 2: (2+9)=11 mod10=1; (9+2)=11 mod10=1. So 1,1

// So for step2, the coefficients for each original digit in the final digit are:
// d0 (3) ×1, d1 (9) ×2, d2 (0) ×1. Then mod10.
// So for the final two digits, each is a combination of the original digits multiplied by some coefficients.

// So the final two digits are (where m = no. of steps)
// digit1 = sum_{i=0 to m} C(m,i)*d_i mod10
// digit2 = sum_{i=0 to m} C(m,i)*d_{i+1} mod10

// Now next question is, how do we compute this quickly, because s.length can be upto 1e5
// C(m, k) mod10 can be computed using Lucas's theorem for prime factors of 10 (2 and 5). But Lucas's theorem applies to primes. So we can compute C(m,k) mod2 and C(m,k) mod5, then combine them using CRT.
// Lucas's theorem states that to compute C(n, k) mod p (for prime p), we can break down n and k into digits in base p and multiply the combinations of their digits.
// Then, using the Chinese Remainder Theorem (CRT), since 2 and 5 are coprime, we can compute C(m,k) mod10 from the values mod2 and mod5.

class Solution {
    public boolean hasSameDigits(String s) {
        var n = s.length() - 2;
        // possible combinations of a (mod2) and b (mod5) and their corresponding x mod10 (using CRT)
        // eg. 0 |0 → 0, 0 |1 → 6, 0 |2 → 2, 0 |3 → 8 and so on
        // so a even number (eg. 8), will have mod2 = 0, mod5 = 3, so look at index [0, 3] which should be 8
        int[][] combTable = {
            {0, 6, 2, 8, 4},    // Even numbers (mod 2 = 0)
            {5, 1, 7, 3, 9}     // Odd numbers (mod 2 = 1)
        };

        var coefficients = new int[n + 1];
        for(var i = 0; i <= n; i++) {
            var mod2Comb = combModP(n, i, 2);
            var mod5Comb = combModP(n, i, 5);
            mod5Comb %= 5;
            coefficients[i] = combTable[mod2Comb][mod5Comb];
        }

        int digit1 = 0, digit2 = 0;
        for(var i = 0; i <= n; i++) {
            var digit = s.charAt(i) - '0';
            digit1 = (digit1 + coefficients[i] * digit) % 10;

            digit = s.charAt(i + 1) - '0';
            digit2 = (digit2 + coefficients[i] * digit) % 10;
        }

        return digit1 == digit2;
    }

    private int combModP(int n, int k, int p) {
        var result = 1;
        while(n > 0 || k > 0) {
            var nRem = n % p;
            var kRem = k % p;
            n /= p;
            k /= p;
            
            if (kRem > nRem)
                return 0;
            result = (result * combModSmall(nRem, kRem, p)) % p;
        }
        return result;
    }

    private int combModSmall(int n, int k, int p) {
        if(p == 2)
            return combMod2(n, k);
        if(p == 5)
            return combMod5(n, k);
        return 0;
    }

    private int combMod2(int n, int k) {
        return (k > n) ? 0 : 1;
    }

    private int combMod5(int n, int k) {
        if(k > n) return 0;
        switch (n) {
            case 0: return 1;
            case 1: return 1;
            case 2:
                switch (k) {
                    case 0: case 2: return 1;
                    case 1: return 2;
                    default: return 0;
                }
            case 3:
                switch (k) {
                    case 0: case 3: return 1;
                    case 1: case 2: return 3;
                    default: return 0;
                }
            case 4:
                switch (k) {
                    case 0: case 4: return 1;
                    case 1: case 3: return 4;
                    case 2: return 1; // 6 mod5=1
                    default: return 0;
                }
            default: return 0;
        }
    }
}
