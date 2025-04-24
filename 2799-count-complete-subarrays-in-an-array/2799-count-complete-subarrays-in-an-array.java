class Solution {
    public int countCompleteSubarrays(int[] nums) {
        int n = nums.length, ans = 0;

        // count unique elements in whole array
        var uniqSet = new HashSet<Integer>();
        for(var num : nums) uniqSet.add(num);
        var uniqCount = uniqSet.size();

        // sliding window to find complete subarrays
        var freq = new HashMap<Integer, Integer>();
        var l = 0;
        for(var r=0; r<n; r++){
            freq.put(nums[r], freq.getOrDefault(nums[r], 0) + 1);
            while(freq.size() == uniqCount){
                ans += n - r;   // adding any element on right will not change curr uniq count

                // move left pointer
                if(freq.get(nums[l]) == 1) freq.remove(nums[l]);
                else freq.put(nums[l], freq.get(nums[l]) - 1);
                l++;
            }
        }

        return ans;
    }
}