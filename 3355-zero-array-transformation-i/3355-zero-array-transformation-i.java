class Solution {
    public boolean isZeroArray(int[] nums, int[][] queries) {
        var n = nums.length;
        var sub = new int[n];   // to track which idx incr starts, and till what index

        for(var query : queries){
            int start = query[0], end = 1 + query[1];
            sub[start]++;
            if(end < n) sub[end]--;
        }

        var curr = 0;
        for(var i=0; i<n; i++){
            curr += sub[i];
            if(nums[i] - curr > 0) return false;
        }

        return true;
    }
}