class Solution {
    fun canWinNim(n: Int): Boolean {
        // return n % 4 != 0
        return n and 3 != 0
    }
}