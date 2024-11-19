class Solution {
    public long maximumSubarraySum(int[] nums, int k) {
        var pos = new int[1_00_001];    // pos of when a number was last seen
        for(var i=0; i<1_00_001; i++) pos[i] = -1;

        var dupIdx = -1;
        long maxSum = 0, currSum = 0;

        for(var i=0; i<nums.length; i++){
            currSum += nums[i];
            if(i >= k) currSum -= nums[i-k];

            // find out index of duplicate num in curr subarray
            dupIdx = Math.max(dupIdx, pos[nums[i]]);
            pos[nums[i]] = i;

            if(i - dupIdx >= k) maxSum = Math.max(maxSum, currSum);
        }

        return maxSum;
    }
}

// Accepted - using map
class SolutionMap {
    public long maximumSubarraySum(int[] nums, int k) {
        var freq = new HashMap<Integer, Integer>();
        long maxSum = 0, currSum = 0;

        for(var i=0; i<k; i++) {
            currSum += nums[i];
            freq.put(nums[i], freq.getOrDefault(nums[i], 0) + 1);
        }
        if(freq.size() == k) maxSum = currSum;
        
        for(var i=k; i<nums.length; i++){
            currSum += nums[i];
            currSum -= nums[i-k];

            freq.put(nums[i], freq.getOrDefault(nums[i], 0) + 1);
            freq.put(nums[i-k], freq.get(nums[i-k]) - 1);

            if(freq.get(nums[i-k]) == 0) freq.remove(nums[i-k]);
            if(freq.size() == k) maxSum = Math.max(maxSum, currSum);
        }

        return maxSum;
    }
}