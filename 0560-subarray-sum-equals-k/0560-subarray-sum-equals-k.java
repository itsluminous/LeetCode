class Solution {
    public int subarraySum(int[] nums, int k) {
        var map = new HashMap<Integer, Integer>();
        map.put(0, 1);
        
        int count = 0, preSum = 0;
        for(var num : nums){
            preSum += num;
            count += map.getOrDefault(preSum - k, 0);
            map.put(preSum, 1 + map.getOrDefault(preSum, 0));
        }
        
        return count;
    }
}