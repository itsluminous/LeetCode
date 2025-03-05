public class Solution {
    public int MaximumUniqueSubarray(int[] nums) {
        int maxSum = 0, currSum = 0, left = 0;
        var uniq = new HashSet<int>();

        for(var right=0; right < nums.Length; right++){
            while(!uniq.Add(nums[right])){
                currSum -= nums[left];
                uniq.Remove(nums[left++]);
            }
            
            currSum += nums[right];
            maxSum = Math.Max(maxSum, currSum);
        }
        
        return maxSum;
    }
}