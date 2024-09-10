// only for multiples of 4, other person can win
class Solution {
public:
    bool canWinNim(int n) {
        // return n % 4;
        return (n & 3);
    }
};