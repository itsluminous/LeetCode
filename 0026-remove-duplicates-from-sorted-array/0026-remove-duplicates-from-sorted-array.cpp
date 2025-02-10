class Solution {
public:
    int removeDuplicates(vector<int>& nums) {
        auto k = 1;
        for(auto i=1; i < nums.size(); i++){
            if(nums[i] != nums[i-1])
                nums[k++] = nums[i];
        }
        return k;
    }
};