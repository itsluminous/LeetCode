class Solution {
public:
    vector<int> lexicalOrder(int n) {
        vector<int> ans;
        helper(0, n, ans);
        return ans;
    }

private:
    void helper(int seed, int max, vector<int>& ans) {
        seed *= 10;
        for(auto i=0; i<10; i++){
            if(seed + i == 0) continue;
            if(seed + i > max) break;
            ans.push_back(seed + i);
            helper(seed + i, max, ans);
        }
    }
};