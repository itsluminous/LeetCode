public class Solution {
    public long MaximumSubarraySum(int[] nums, int k) {
        var pos = new int[1_00_001];    // pos of when a number was last seen
        for(var i=0; i<1_00_001; i++) pos[i] = -1;

        var dupIdx = -1;
        long maxSum = 0, currSum = 0;

        for(var i=0; i<nums.Length; i++){
            currSum += nums[i];
            if(i >= k) currSum -= nums[i-k];

            // find out index of duplicate num in curr subarray
            dupIdx = Math.Max(dupIdx, pos[nums[i]]);
            pos[nums[i]] = i;

            if(i - dupIdx >= k) maxSum = Math.Max(maxSum, currSum);
        }

        return maxSum;
    }
}

// Accepted - using Dict
public class SolutionDict {
    public long MaximumSubarraySum(int[] nums, int k) {
        var freq = new Dictionary<int, int>();
        long maxSum = 0, currSum = 0;

        for(var i=0; i<k; i++) {
            currSum += nums[i];
            if(freq.ContainsKey(nums[i])) freq[nums[i]]++;
            else freq[nums[i]] = 1;
        }
        if(freq.Count == k) maxSum = currSum;
        
        for(var i=k; i<nums.Length; i++){
            currSum += nums[i];
            currSum -= nums[i-k];

            if(freq.ContainsKey(nums[i])) freq[nums[i]]++;
            else freq[nums[i]] = 1;
            freq[nums[i-k]]--;

            if(freq[nums[i-k]] == 0) freq.Remove(nums[i-k]);
            if(freq.Count == k) maxSum = Math.Max(maxSum, currSum);
        }

        return maxSum;
    }
}