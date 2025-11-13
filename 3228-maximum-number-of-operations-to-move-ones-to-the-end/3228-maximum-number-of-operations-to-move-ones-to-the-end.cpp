class Solution {
public:
    int maxOperations(string s) {
        int count = 0, prev = 0;
        for (int i = s.size() - 2; i >= 0; --i) {
            if (s[i] == '1') {
                prev = (s[i + 1] == '0') ? prev + 1 : prev;
                count += prev;
            }
        }
        return count;
    }
};