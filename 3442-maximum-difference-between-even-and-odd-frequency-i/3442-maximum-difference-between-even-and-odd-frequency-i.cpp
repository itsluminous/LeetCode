class Solution {
public:
    int maxDifference(string s) {
        vector<int> freq(26, 0);
        for(auto ch : s)
            freq[ch-'a']++;

        int oddMax = 0, evenMin = 101;
        for(auto f : freq){
            if(f == 0) continue;
            if((f & 1) == 1) oddMax = max(oddMax, f);
            else evenMin = min(evenMin, f);
        }

        return oddMax - evenMin;
    }
};