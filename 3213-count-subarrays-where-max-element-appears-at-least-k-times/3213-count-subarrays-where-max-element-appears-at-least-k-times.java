class Solution {
    public long countSubarrays(int[] nums, int k) {
        long ans = 0;
        int maxNum = Arrays.stream(nums).max().getAsInt(), maxCount = 0;

        for(int l=0, r=0; r < nums.length; r++){
            if(nums[r] == maxNum) maxCount++;

            while(maxCount == k)
                if(nums[l++] == maxNum)
                    maxCount--;
            
            ans += l;
        }
        return ans;
    }
}