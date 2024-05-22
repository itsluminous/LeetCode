class Solution {
    public int rob(int[] nums) {
        int doRob = 0, dontRob = 0;
        for(var i=0; i<nums.length; i++){
            var currRob = nums[i] + dontRob;
            dontRob = Math.max(dontRob, doRob);
            doRob = currRob;
        }
        return Math.max(doRob, dontRob);
    }
}