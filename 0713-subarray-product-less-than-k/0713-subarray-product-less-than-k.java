class Solution {
    public int numSubarrayProductLessThanK(int[] nums, int k) {
        int n = nums.length, count = 0, product = 1;
        for(int l=0, r=0; r<n; r++){
            product *= nums[r];
            // whenever product is >= k, then we shift the l pointer to right
            while(product >= k && l<=r)
                product /= nums[l++];
            count += r-l+1;     // these are all combinations between current l and r
        }
        return count;
    }
}