class Solution {
    func canWinNim(_ n: Int) -> Bool {
        // return n % 4 != 0;
        return (n & 3) != 0;
    }
}