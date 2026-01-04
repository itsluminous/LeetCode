// explaination : https://leetcode.com/problems/number-of-ways-to-paint-n-3-grid/solutions/574923/javacpython-dp-o1-space-by-lee215-cr89
public class Solution {
    public int NumOfWays(int n) {
        var MOD = 1_000_000_007;
        // a121: 121, 131, 212, 232, 313, 323
        // a123: 123, 132, 213, 231, 312, 321
        long a121 = 6, a123 = 6;

        // b121: 212, 213, 232, 312, 313    = 3 * 121 + 2 * 123
        // b123: 212, 231, 312, 232         = 2 * 121 + 2 * 123
        long b121 = 0, b123 = 0;

        for(var i=1; i<n; i++){
            b121 = 3 * a121 + 2 * a123;
            b123 = 2 * a121 + 2 * a123;
            a121 = b121 % MOD;
            a123 = b123 % MOD;
        }

        return (int)((a121 + a123) % MOD);
    }
}