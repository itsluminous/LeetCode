class Solution {
public:
    int prefixCount(vector<string>& words, string pref) {
        auto count = 0;
        for(auto word : words)
            if(word.find(pref) == 0) count++;
        return count;
    }
};