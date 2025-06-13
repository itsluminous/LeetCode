class Solution {
    public int minimizeMax(int[] nums, int p) {
        if(p == 0) return 0;
        var n = nums.length;
        Arrays.sort(nums);

        int l = 0, r = nums[n-1] - nums[0];
        while(l < r){
            var mid = l + (r - l) / 2;
            if(hasPairs(nums, p, mid)) r = mid;
            else l = mid + 1;

        }
        return l;
    }

    private boolean hasPairs(int[] nums, int p, int maxDiff){
        var count = 0;
        for(var i=0; i<nums.length-1; i++){
            if(nums[i+1] - nums[i] <= maxDiff){
                i++;    // skip next element also as we included in current
                count++;
                if(count >= p) return true;
            }
        }
        return false;
    }
}