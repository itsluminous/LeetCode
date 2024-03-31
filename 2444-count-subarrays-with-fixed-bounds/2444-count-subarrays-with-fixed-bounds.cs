public class Solution {
    public long CountSubarrays(int[] nums, int minK, int maxK) {
        int minIdx = -1, maxIdx = -1;   // track latest index where minK and maxK are found

        long ans = 0;
        var l = 0;
        for(var r=0; r<nums.Length; r++){
            // if we found any num >maxK or <minK, we need to start over
            if(nums[r] > maxK || nums[r] < minK){
                l = r+1;
                minIdx = -1; maxIdx = -1;
                continue;
            }

            // update latest index where minK or maxK are found
            if(nums[r] == minK) minIdx = r;
            if(nums[r] == maxK) maxIdx = r;

            // if we have both minIdx & maxIdx in subarr, increase answer count
            if(minIdx > -1 && maxIdx > -1){
                var leftSideIdx = Math.Min(minIdx, maxIdx);
                ans += (leftSideIdx-l+1);
            }
        }

        return ans;
    }
}