class Solution {
    public boolean hasIncreasingSubarrays(List<Integer> nums, int k) {
        var n = nums.size();

        for(var i=0; i<= n-2*k; i++){
            if(isIncreasingSubarray(nums, i, k) && isIncreasingSubarray(nums, i+k, k))
                return true;
        }
        return false;
    }

    private boolean isIncreasingSubarray(List<Integer> nums, int start, int k){
        for(var i=1; i<k; i++)
            if(nums.get(start + i) <= nums.get(start + i - 1))
                return false;
        return true;
    }
}