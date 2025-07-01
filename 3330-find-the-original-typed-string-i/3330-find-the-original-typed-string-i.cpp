class Solution {
public:
    int possibleStringCount(string word) {
        auto ans = 1;    // 1 = full string
        for(auto i=1; i<word.size(); i++)
            if(word[i] == word[i-1])
                ans++;
        return ans;
    }
};