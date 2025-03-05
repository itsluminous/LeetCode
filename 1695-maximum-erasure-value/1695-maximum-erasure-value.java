class Solution {
    public int maximumUniqueSubarray(int[] nums) {
        int maxSum = 0, currSum = 0, left = 0;
        var uniq = new HashSet<Integer>();

        for(var right=0; right < nums.length; right++){
            while(!uniq.add(nums[right])){
                currSum -= nums[left];
                uniq.remove(nums[left++]);
            }
            
            currSum += nums[right];
            maxSum = Math.max(maxSum, currSum);
        }
        
        return maxSum;
    }
}