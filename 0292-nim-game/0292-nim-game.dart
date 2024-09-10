class Solution {
  bool canWinNim(int n) {
    // return n % 4 != 0;
    return (n & 3) != 0;
  }
}