public class Solution {
    public int maxFrequency(int[] nums, int k) {
        Arrays.sort(nums);
        int n = nums.length, l = 0, r = 0;
        long sum = 0;
        
        for(; r<n; r++){
            sum += nums[r];
            var operationsToMakeAllSame = (long)(r-l+1)*nums[r] - sum;
            if(operationsToMakeAllSame > k){
                sum -= nums[l];
                l++;
            }
        }

        return r-l;
    }
}