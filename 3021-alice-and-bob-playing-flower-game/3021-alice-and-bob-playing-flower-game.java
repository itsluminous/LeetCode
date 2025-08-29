class Solution {
    public long flowerGame(int n, int m) {
        long nOdd = (n % 2 == 0) 
                    ? ((long)(n / 2) * (long)(m / 2)) 
                    : ((long)(n / 2 + 1) * (long)(m / 2));
                    
        long mOdd = (m % 2 == 0) 
                    ? ((long)(m / 2) * (long)(n / 2)) 
                    : ((long)(m / 2 + 1) * (long)(n / 2));
                    
        return nOdd + mOdd; // Alice can win only when x+y is odd number
    }
}