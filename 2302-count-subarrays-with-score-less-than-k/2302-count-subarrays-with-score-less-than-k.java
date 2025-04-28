class Solution {
    public long countSubarrays(int[] nums, long k) {
        long count = 0, total = 0;
        for(int l=0, r=0; r < nums.length; r++){
            total += nums[r];
            // shift left pointer till a good subarray is found
            while(l <= r && total * (r - l + 1) >= k)
                total -= nums[l++];
            
            // between l & r, we have (r - l + 1) subarrays, because any smaller subarray is guarateed to be < k
            count += r - l + 1;
        }
        return count;
    }
}