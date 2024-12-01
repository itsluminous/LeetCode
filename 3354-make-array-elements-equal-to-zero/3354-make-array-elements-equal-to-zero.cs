// prefixSum : track sum on left of zero and right if zero
public class Solution {
    public int CountValidSelections(int[] nums) {
        var n = nums.Length;
        int[] leftSum = new int[n], rightSum = new int[n];

        for(var i=1; i<n; i++){
            leftSum[i] = leftSum[i-1] + nums[i-1];
            rightSum[n-i-1] = rightSum[n-i] + nums[n-i];
        }

        var ans = 0;
        for(var i=0; i<n; i++){
            if(nums[i] != 0) continue;
            var diff = Math.Abs(leftSum[i] - rightSum[i]);
            if(diff == 0) ans += 2; // we can go in left & right dir both
            if(diff == 1) ans += 1; // we can go only in one direction
        }

        return ans;
    }
}