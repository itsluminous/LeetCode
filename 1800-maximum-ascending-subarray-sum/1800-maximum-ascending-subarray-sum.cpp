class Solution {
public:
    int maxAscendingSum(vector<int>& nums) {
        int maxSum = nums[0], currSum = nums[0];
        
        for(auto i=1; i<nums.size(); i++){
            if(nums[i] <= nums[i-1]) {
                maxSum = std::max(maxSum, currSum);
                currSum = nums[i];
            } else {
                currSum += nums[i];
            }
        }
        maxSum = std::max(maxSum, currSum);
        return maxSum;
    }
};