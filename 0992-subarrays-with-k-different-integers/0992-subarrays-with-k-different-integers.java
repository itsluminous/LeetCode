public class Solution {
    public int subarraysWithKDistinct(int[] nums, int k) {
        return subarraysWithKOrLessDistinct(nums, k) - subarraysWithKOrLessDistinct(nums, k-1);
    }

    private int subarraysWithKOrLessDistinct(int[] nums, int k) {
        var freq = new HashMap<Integer, Integer>();
        int n = nums.length, count = 0, l = 0;

        for(var r=0; r<n; r++){
            freq.put(nums[r], freq.getOrDefault(nums[r], 0) + 1);

            while(freq.size() > k){
                freq.put(nums[l], freq.get(nums[l]) -1);
                if(freq.get(nums[l]) == 0) freq.remove(nums[l]);
                l++;
            }
            count += (r-l+1);
        }

        return count;
    }
}