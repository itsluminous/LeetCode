public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        var memo = new Dictionary<int, int>();
        for(int i=0; i<nums.Length; i++){
            if(memo.ContainsKey(nums[i]))
                return [memo[nums[i]], i];
            else
                memo[target - nums[i]] = i;
        }
        return null;
    }
}