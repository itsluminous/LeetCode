class Solution {
    public int countHillValley(int[] nums) {
        int n = nums.length, ans = 0, start = 1;

        // skip all initial equal numbers
        while(start < n && nums[start] == nums[start-1]) start++;
        if(start == n) return 0;

        // find all maxima and minima
        var dir = nums[start] > nums[start-1] ? 1 : -1;    // 1 = up, -1 = down
        for(var i=start+1; i<n; i++){
            if(nums[i] == nums[i-1]) continue;  // equal neighbour
            
            var newDir = nums[i] > nums[i-1] ? 1 : -1;
            if(newDir != dir) ans++;    // found maxima or minima
            dir = newDir;
        }

        return ans;
    }
}