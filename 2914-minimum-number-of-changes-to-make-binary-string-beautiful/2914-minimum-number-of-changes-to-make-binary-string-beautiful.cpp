class Solution {
public:
    int minChanges(string s) {
        auto count = 0;
        for(auto i=1; i<s.size(); i+=2)
            if(s[i] != s[i-1])
                count++;
        
        return count;
    }
};