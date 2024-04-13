public class Solution {
    public int MaxFrequency(int[] nums, int k) {
        Array.Sort(nums);
        int n = nums.Length, l = 0, r = 0;
        long sum = 0;
        
        for(; r<n; r++){
            sum += nums[r];
            var operationsToMakeAllSame = Convert.ToInt64(r-l+1)*nums[r] - sum;
            if(operationsToMakeAllSame > k){
                sum -= nums[l];
                l++;
            }
        }

        return r-l;
    }
}