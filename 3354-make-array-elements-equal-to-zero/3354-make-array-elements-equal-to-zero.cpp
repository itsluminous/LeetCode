class Solution {
public:
    int countValidSelections(vector<int>& nums) {
        auto n = nums.size();
        vector<int> leftSum(n, 0), rightSum(n, 0);

        for(auto i=1; i<n; i++){
            leftSum[i] = leftSum[i-1] + nums[i-1];
            rightSum[n-i-1] = rightSum[n-i] + nums[n-i];
        }

        auto ans = 0;
        for(auto i=0; i<n; i++){
            if(nums[i] != 0) continue;
            auto diff = abs(leftSum[i] - rightSum[i]);
            if(diff == 0) ans += 2; // we can go in left & right dir both
            if(diff == 1) ans += 1; // we can go only in one direction
        }

        return ans;
    }
};