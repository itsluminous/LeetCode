// only for multiples of 4, other person can win
public class Solution {
    public bool CanWinNim(int n) {
        // return n % 4 != 0;
        return (n & 3) != 0;
    }
}