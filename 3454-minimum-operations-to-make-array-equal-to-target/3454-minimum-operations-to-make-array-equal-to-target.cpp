class Solution {
public:
    long long minimumOperations(vector<int>& nums, vector<int>& target) {
        int n = nums.size();
        long incr = 0, decr = 0, ops = 0;

        for (int i = 0; i < n; i++) {
            long diff = target[i] - nums[i];

            if (diff > 0) {
                if (incr < diff)
                    ops += diff - incr;
                incr = diff;
                decr = 0;
            } else if (diff < 0) {
                if (diff < decr)
                    ops += decr - diff;
                decr = diff;
                incr = 0;
            } else {
                incr = decr = 0;
            }
        }

        return ops;
    }
};