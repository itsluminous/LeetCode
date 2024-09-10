func canWinNim(n int) bool {
    // return n % 4 != 0
    return n & 3 != 0
}