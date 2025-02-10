class Solution {
public:
    string clearDigits(string s) {
        string alpha;
        for(auto ch : s)
            if(isdigit(ch))
                alpha.pop_back();   // alpha will always have something
            else
                alpha.push_back(ch);
        
        return alpha;
    }
};