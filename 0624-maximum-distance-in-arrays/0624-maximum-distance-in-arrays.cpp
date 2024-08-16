class Solution {
public:
    int maxDistance(vector<vector<int>>& arrays) {
        auto smallest = 10001, biggest = -10001, maxDist = 0;
        for(auto& arr : arrays){
            maxDist = std::max(maxDist, biggest - arr[0]);
            maxDist = std::max(maxDist, arr[arr.size()-1] - smallest);
            smallest = std::min(smallest, arr[0]);
            biggest = std::max(biggest, arr[arr.size()-1]);
        }

        return maxDist;
    }
};