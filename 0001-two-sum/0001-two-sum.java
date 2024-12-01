class Solution {
    public int[] twoSum(int[] nums, int target) {
        var memo = new HashMap<Integer, Integer>();
        for(int i=0; i<nums.length; i++){
            if(memo.containsKey(nums[i]))
                return new int[]{memo.get(nums[i]), i};
            else
                memo.put(target - nums[i], i);
        }
        return null;
    }
}