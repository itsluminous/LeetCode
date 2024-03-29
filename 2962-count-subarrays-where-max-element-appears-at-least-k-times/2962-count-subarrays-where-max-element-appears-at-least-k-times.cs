public class Solution {
    public long CountSubarrays(int[] nums, int k) {
        var max = nums.Max();
        long ans = 0;
        int n = nums.Length, left = 0, maxElementsInWindow = 0;
        
        for(var right = 0; right < nums.Length; right++){
            if(nums[right] == max) 
                maxElementsInWindow++;

            while(maxElementsInWindow == k)
                if(nums[left++] == max) 
                    maxElementsInWindow--;
            ans += left;
        }

        return ans;
    }
}