class Solution {
    public int numberOfSubarrays(int[] nums, int k) {
        var n = nums.length;
        Map<Integer,  Integer> prefixSum = new HashMap<>();
        prefixSum.put(0, 1);

        int currSum = 0, subarrays = 0;
        for(var num : nums){
            currSum += (num % 2);
            if(prefixSum.containsKey(currSum - k))
                subarrays += prefixSum.get(currSum - k);
            
            prefixSum.put(currSum, prefixSum.getOrDefault(currSum, 0) + 1);
        }

        return subarrays;
    }
}