// Using permutation
public class Solution {
    public int CountOrders(int n) {
        var MOD = 1_000_000_007;
        long ans = 1;
        
        for(var i=1; i<=n; i++){
            // Ways to arrange all pickups, 1*2*3*4*5*...*n
            ans = ans * i;  // factorial
            // Ways to arrange all deliveries, 1*3*5*...*(2n-1)
            ans = ans * (2 * i - 1);
            
            ans %= MOD;
        }
        
        return (int)ans;
    }
}