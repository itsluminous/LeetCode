public class Solution {
    public int LongestNiceSubarray(int[] nums) {
        int max = 1, n = nums.Length, left = 0;
        while(left < n && n - left > max){
            var allBits = nums[left];
            var right = left+1;
            for(; right<n; right++){
                if((allBits & nums[right]) != 0) break;
                allBits |= nums[right];
            }
            max = Math.Max(max, right - left);
            left++;
        }
        
        return max;
    }
}