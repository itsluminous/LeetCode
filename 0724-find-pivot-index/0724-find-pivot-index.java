class Solution {
    public int pivotIndex(int[] nums) {
        var n = nums.length;
        var pref = new int[n];

        for(var i=n-2; i>=0; i--)
            pref[i] = nums[i+1] + pref[i+1];

        var left = 0;
        for(var i=0; i<n; i++){
            if(left == pref[i]) return i;
            left += nums[i];
        }
        return -1;
    }
}