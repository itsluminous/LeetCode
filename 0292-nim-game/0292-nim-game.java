// only for multiples of 4, other person can win
class Solution {
    public boolean canWinNim(int n) {
        // return n % 4 != 0;
        return (n & 3) != 0;
    }
}