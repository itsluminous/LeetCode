public class Solution {
    int MOD = 1_000_000_007;

    public int CountGoodNumbers(long n) {
        var oddCount = 4;   // can be 2, 3, 5, 7
        var evenCount = 5;  // can be 0, 2, 4, 6, 8

        var oddPos = n / 2;         // n/2 positions will have odd index
        var evenPos = n - oddPos;   // remaining positions are even
        
        return (int)((Power(oddCount, oddPos) * Power(evenCount, evenPos)) % MOD);
    }

    // calculate x^y efficiently
    private long Power(long x, long y){
        long ans = 1;
        while(y > 0){
            if((y & 1) == 1)
                ans = (ans * x) % MOD;
            
            y >>= 1;    // divide y by 2
            x = (x * x) % MOD;
        }

        return ans % MOD;
    }
}