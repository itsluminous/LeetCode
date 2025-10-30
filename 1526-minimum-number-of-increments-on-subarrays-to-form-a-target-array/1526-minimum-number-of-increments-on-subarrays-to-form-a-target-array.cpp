class Solution {
public:
    int minNumberOperations(vector<int>& target) {
        int ops = 0, incr = 0;
        for(auto num : target){
            if(num > incr)
                ops += (num - incr);
            incr = num;
        }

        return ops;
    }
};