// This solution is using prefix sum, but can also be done using sliding window
public class Solution {
    public int[] GetAverages(int[] nums, int k) {
        var n = nums.Length;
        var divider = k*2 + 1;
        var lSum = new long[n];
        long leftSum = 0;
        for(var i=0; i<n; i++){
            leftSum += nums[i];
            if(i<k){
                lSum[i] = -1;
            }
            else{
                lSum[i] = leftSum;
                leftSum -= nums[i-k];
            }
        }
        
        var result = new int[n];
        long rightSum = 0;
        for(var i=n-1; i>=0; i--){
            if(i+k >= n)
                result[i] = -1;
            else if(i<k)
                result[i] = -1;
            else
                result[i] = (int)((lSum[i] + rightSum)/divider);
            rightSum += nums[i];
            if(i+k < n)
                rightSum -= nums[i+k];
        }
        
        return result;
    }
}