// Bob can only win if total count of vowels is 0
class Solution {
public:
    bool doesAliceWin(string s) {
        for (char ch : s) {
            if (ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u')
                return true;
        }
        return false;
    }
};