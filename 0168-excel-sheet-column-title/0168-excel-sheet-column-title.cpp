class Solution {
public:
    string convertToTitle(int columnNumber) {
        string ans;
        while(columnNumber){
            columnNumber--;
            int remainder = columnNumber % 26;
            columnNumber /= 26;

            char ch = (char) ('A' + remainder);
            ans += ch;
        }

        reverse(ans.begin(), ans.end());
        return ans;
    }
};