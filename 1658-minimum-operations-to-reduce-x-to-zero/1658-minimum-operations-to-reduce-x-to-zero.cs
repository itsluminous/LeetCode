// idea is to find biggest subsequence with sum value of {total sum(nums) - x}
public class Solution {
    public int MinOperations(int[] nums, int x) {
        int left=0,maxLen = -1, currWindowSum = 0, total = 0;;
        for(int i=0;i<nums.Length;i++) total+=nums[i];  // prefix sum
        
        for(var right=0; right<nums.Length; right++)
        {
            currWindowSum += nums[right];
            // if current sum becomes more than expected, shift left side of window
            while(currWindowSum > total - x && left <= right)
                currWindowSum -= nums[left++];
            // if the current sum is exactly as expected, then check if this subsequence is biggest length
            if(currWindowSum == total-x)
                maxLen = Math.Max(maxLen,right-left+1);
        }
        
        return maxLen == -1 ? -1 : nums.Length - maxLen;
    }
}