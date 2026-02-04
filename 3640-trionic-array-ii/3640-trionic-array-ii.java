class Solution {
    public long maxSumTrionic(int[] nums) {
        var n = nums.length;
        long ans = Long.MIN_VALUE, sum = nums[0];
        for(int l=0, r=1, peak=0, valley=0; r < n; r++){
            sum += nums[r];
            // same level = reset
            if(nums[r] == nums[r-1]){
                sum = nums[r];
                l = r;
            }
            // found down slope
            else if(nums[r] < nums[r-1]){
                // expand on left
                if(r > 1 && nums[r-2] < nums[r-1]){
                    peak = r-1;
                    while(l < valley) sum -= nums[l++];
                    while(l+1 < peak && nums[l] < 0) sum -= nums[l++];
                }
            }
            // found up slope
            else {
                if(r > 1 && nums[r-2] > nums[r-1])  valley = r-1;
                if(l < peak && peak < valley) ans = Math.max(ans, sum);
            }
        }

        return ans;
    }
}