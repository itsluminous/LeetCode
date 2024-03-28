public class Solution {
    public int maxSubarrayLength(int[] nums, int k) {
        int n = nums.length, l = 0, r = 0, max = 1;
        var freq = new HashMap<Integer, Integer>();

        while(r < n){
            freq.put(nums[r], freq.getOrDefault(nums[r], 0) + 1);

            while(freq.get(nums[r]) > k){
                freq.put(nums[l], freq.get(nums[l]) - 1);
                l++;
            }
            max = Math.max(max, r-l+1);
            r++;
        }

        return max;
    }
}