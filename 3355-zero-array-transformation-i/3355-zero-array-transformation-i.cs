public class Solution {
    public bool IsZeroArray(int[] nums, int[][] queries) {
        var n = nums.Length;
        var sub = new int[n];   // to track which idx incr starts, and till what index

        foreach(var query in queries){
            var (start, end) = (query[0], 1 + query[1]);
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