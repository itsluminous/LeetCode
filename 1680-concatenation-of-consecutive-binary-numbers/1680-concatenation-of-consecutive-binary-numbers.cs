public class Solution {
    public int ConcatenatedBinary(int n) {
        var MOD = 1_000_000_007;
        long result = 0;
        var binaryDigits = 0;       // number of binary digits needed to represent a number
        for(var i=1; i<=n; i++){
            if((i & (i-1)) == 0) binaryDigits++;
            result = ((result << binaryDigits) + i) % MOD;
        }
        return (int) result;
    }
}