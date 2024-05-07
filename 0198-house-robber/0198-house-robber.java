class Solution {
    public int rob(int[] nums) {
        int notRob = 0, rob = nums[0];
        for(var i=1; i<nums.length; i++){
            var notRobCurr = Math.max(notRob, rob);
            rob = notRob + nums[i];
            notRob = notRobCurr;
        }

        return Math.max(rob, notRob);
    }
}