public class Solution {
    public int BeautifulSubsets(int[] nums, int k) {
        var map = new Dictionary<int, int>();
        return DFS(nums, k, map, 0) - 1;    // subtract 1 for empty subset
    }
    
    private int DFS(int[] nums, int k, Dictionary<int, int> map, int idx){
        if(idx == nums.Length) return 1;

        var notTakeCurr = DFS(nums, k, map, idx+1);
        var takeCurr = 0;
        if(!map.ContainsKey(nums[idx] - k) && !map.ContainsKey(nums[idx] + k)){
            if(map.ContainsKey(nums[idx])) map[nums[idx]]++;
            else map[nums[idx]] = 1;
            takeCurr = DFS(nums, k, map, idx+1);
            if(map[nums[idx]] == 1) map.Remove(nums[idx]);
            else map[nums[idx]]--;
        }

        return notTakeCurr + takeCurr;
    }
}