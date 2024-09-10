object Solution {
    def canWinNim(n: Int): Boolean = {
        // n % 4 != 0
        (n & 3) != 0
    }
}