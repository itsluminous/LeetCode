public class Solution {
    public long FlowerGame(int n, int m) {
        long nOdd = n%2 == 0 ? (Convert.ToInt64(n/2) * Convert.ToInt64(m/2)) : (Convert.ToInt64(n/2 + 1) * Convert.ToInt64(m/2));
        long mOdd = m%2 == 0 ? (Convert.ToInt64(m/2) * Convert.ToInt64(n/2)) : (Convert.ToInt64(m/2 + 1) * Convert.ToInt64(n/2));
        
        return nOdd + mOdd; // Alice can win only when x+y is odd number
    }
}