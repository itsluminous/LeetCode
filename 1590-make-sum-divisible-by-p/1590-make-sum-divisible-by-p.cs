// consider rem to be the sum of subarray that we want to remove
// the question is essentially find the shortest subarray with sum % p = rem 
public class Solution {
    public int MinSubarray(int[] nums, int p) {
        // find out what is the target sum of subarray that needs to be removed
        var remainder = 0;
        foreach(var num in nums)
            remainder = (num + remainder) % p;
        if(remainder == 0) return 0;

        // map to track most recent index of when a remainder was seen
        // most recent because we want to minimize the size of array
        var map = new Dictionary<int, int>();
        map[0] = -1;

        var n = nums.Length;
        int ans = n, preSum = 0;
        for(var i=0; i<n; i++){
            preSum = (preSum + nums[i]) % p;    // we only care about remainder in prefixSum
            map[preSum] = i;                    // track most recent index of when have we seen this remainder

            var key = (p + preSum - remainder) % p; // if remainder is 10, and curr preSum is 4, we want to search for key=6
            if(map.ContainsKey(key))
                ans = Math.Min(ans, i - map[key]);
        }

        if(ans < n) return ans;
        return -1;
    }
};