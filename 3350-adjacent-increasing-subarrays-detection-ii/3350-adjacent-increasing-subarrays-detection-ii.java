class Solution {
    public int maxIncreasingSubarrays(List<Integer> nums) {
        int k = 0, prev = 0, curr = 1;    // prev is length of prev increasing subarray
        for(var i=1; i<nums.size(); i++){
            if(nums.get(i) > nums.get(i-1)){
                curr++;
                continue;
            }
            k = getMaxLength(prev, curr, k);
            prev = curr;
            curr = 1;
        }

        k = getMaxLength(prev, curr, k);
        return k;
    }

    private int getMaxLength(int prev, int curr, int k){
        var kk = Math.min(prev, curr); // length of k for prev & curr subarrays
        kk = Math.max(kk, curr/2);
        k = Math.max(k, kk);
        return k;
    }
}