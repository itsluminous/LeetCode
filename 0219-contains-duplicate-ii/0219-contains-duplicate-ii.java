class Solution {
    public boolean containsNearbyDuplicate(int[] nums, int k) {
        var seen = new HashSet<Integer>();
        for(var i=0; i<nums.length; i++){
            if(!seen.add(nums[i])) return true;
            if(i >= k) seen.remove(nums[i-k]);
        }

        return false;
    }
}