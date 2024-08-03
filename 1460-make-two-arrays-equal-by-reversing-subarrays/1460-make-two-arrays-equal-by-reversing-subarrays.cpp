class Solution {
public:
    bool canBeEqual(vector<int>& target, vector<int>& arr) {
        vector<int> freq(1001, 0);
        for (int num : arr) freq[num]++;

        for (int num : target) {
            freq[num]--;
            if(freq[num] == -1) return false;
        }

        return true;
    }
};