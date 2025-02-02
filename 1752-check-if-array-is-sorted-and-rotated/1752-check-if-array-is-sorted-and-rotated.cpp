class Solution {
public:
    bool check(vector<int>& nums) {
        auto n = nums.size();
        auto rotated = false;

        for(auto i=1; i<n; i++){
            if(nums[i] >= nums[i-1]) continue;
            if(rotated) return false;
            rotated = true;
        }

        return (!rotated || nums[0] >= nums[n-1]);
    }
};