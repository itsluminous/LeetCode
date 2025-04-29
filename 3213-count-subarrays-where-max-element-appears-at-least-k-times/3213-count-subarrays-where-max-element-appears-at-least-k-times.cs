public class Solution {
    public long CountSubarrays(int[] nums, int k) {
        long ans = 0;
        int maxNum = nums.Max(), maxCount = 0;

        for(int l=0, r=0; r < nums.Length; r++){
            if(nums[r] == maxNum) maxCount++;

            while(maxCount == k)
                if(nums[l++] == maxNum)
                    maxCount--;
            
            ans += l;
        }
        return ans;
    }
}