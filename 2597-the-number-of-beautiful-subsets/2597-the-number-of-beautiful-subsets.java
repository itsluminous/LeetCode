class Solution {
    public int beautifulSubsets(int[] nums, int k) {
        var map = new HashMap<Integer, Integer>();
        return dfs(nums, k, map, 0) - 1;    // subtract 1 for empty subset
    }
    
    private int dfs(int[] nums, int k, HashMap<Integer, Integer> map, int idx){
        if(idx == nums.length) return 1;

        var notTakeCurr = dfs(nums, k, map, idx+1);
        var takeCurr = 0;
        if(!map.containsKey(nums[idx] - k) && !map.containsKey(nums[idx] + k)){
            map.put(nums[idx], map.getOrDefault(nums[idx], 0) + 1);
            takeCurr = dfs(nums, k, map, idx+1);
            map.put(nums[idx], map.get(nums[idx]) - 1);
            if(map.get(nums[idx]) == 0) map.remove(nums[idx]);
        }

        return notTakeCurr + takeCurr;
    }
}