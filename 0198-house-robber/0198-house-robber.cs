public class Solution {
    public int Rob(int[] nums) {
        int notRob = 0, rob = nums[0];
        for(var i=1; i<nums.Length; i++){
            var notRobCurr = Math.Max(notRob, rob);
            rob = notRob + nums[i];
            notRob = notRobCurr;
        }

        return Math.Max(rob, notRob);
    }
}