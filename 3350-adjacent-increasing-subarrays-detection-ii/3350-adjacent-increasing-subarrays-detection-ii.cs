public class Solution {
    public int MaxIncreasingSubarrays(IList<int> nums) {
        int k = 0, prev = 0, curr = 1;    // prev is length of prev increasing subarray
        for(var i=1; i<nums.Count; i++){
            if(nums[i] > nums[i-1]){
                curr++;
                continue;
            }
            k = GetMaxLength(prev, curr, k);
            prev = curr;
            curr = 1;
        }

        k = GetMaxLength(prev, curr, k);
        return k;
    }

    private int GetMaxLength(int prev, int curr, int k){
        var kk = Math.Min(prev, curr); // length of k for prev & curr subarrays
        kk = Math.Max(kk, curr/2);
        k = Math.Max(k, kk);
        return k;
    }
}