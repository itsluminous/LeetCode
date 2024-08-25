public class Solution {
    public bool ContainsNearbyDuplicate(int[] nums, int k) {
        var seen = new HashSet<int>();
        for(var i=0; i<nums.Length; i++){
            if(!seen.Add(nums[i])) return true;
            if(i >= k) seen.Remove(nums[i-k]);
        }

        return false;
    }
}