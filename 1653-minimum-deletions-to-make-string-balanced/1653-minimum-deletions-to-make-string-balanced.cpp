class Solution {
public:
    int minimumDeletions(string s) {
        int minDel = 0, b = 0;
        for(auto ch : s){
            if(ch == 'b')
                b++;
            else
                minDel = min(minDel + 1, b);
        }

        return minDel;
    }
};