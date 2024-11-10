public class Solution {
    public bool HasIncreasingSubarrays(IList<int> nums, int k) {
        var n = nums.Count;

        for(var i=0; i<= n-2*k; i++){
            if(IsIncreasingSubarray(nums, i, k) && IsIncreasingSubarray(nums, i+k, k))
                return true;
        }
        return false;
    }

    private bool IsIncreasingSubarray(IList<int> nums, int start, int k){
        for(var i=1; i<k; i++)
            if(nums[start + i] <= nums[start + i - 1])
                return false;
        return true;
    }
}